/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Ninject;
using VersionOne.JiraConnector;
using VersionOne.Profile;
using VersionOne.ServiceHost.ServerConnector;
using VersionOne.ServiceHost.Core.Services;
using VersionOne.ServiceHost.Core.Utility;
using VersionOne.ServiceHost.Eventing;
using VersionOne.ServiceHost.Core.Logging;
using VersionOne.ServiceHost.JiraServices.Exceptions;
using VersionOne.ServiceHost.WorkitemServices;

using ConfigurationException = VersionOne.ServiceHost.Core.Utility.ConfigurationException;
using StartupChecker = VersionOne.ServiceHost.JiraServices.StartupValidation.StartupChecker;

namespace VersionOne.ServiceHost.JiraServices
{
    /// <summary>
    /// A service that:
    ///		1) Polls JIRA on a configurable interval for Issues to create in VersionOne.
    ///		2) Listens for Defects created in VersionOne and updates the corresponding issues in JIRA.
    /// </summary>
    public class JiraHostedService : IHostedService, IComponentProvider
    {
        public class IntervalSync { }

        private IJiraIssueProcessor jiraProcessor;
        private IEventManager eventManager;
        private ILogger logger;
        private JiraServiceConfiguration jiraConfig;
        private XmlElement config;

        private StartupChecker startupChecker;

        public void Initialize(XmlElement config, IEventManager eventManager, IProfile profile)
        {
            this.eventManager = eventManager;
            this.config = config;
            logger = new Logger(eventManager);

            try
            {
                jiraConfig = GetValuesFromConfiguration();
            }
            catch (Exception ex)
            {
                logger.Log(LogMessage.SeverityType.Error, "Error during reading settings from configuration file.", ex);
                return;
            }

            if (jiraConfig.Url == null)
            {
                throw new ConfigurationException("Cannot initialize JIRA Service without a URL");
            }
        }

        public void Start()
        {
            startupChecker.Initialize();
            eventManager.Subscribe(typeof(IntervalSync), OnInterval);
            eventManager.Subscribe(typeof(WorkitemCreationResult), OnWorkitemCreated);
            eventManager.Subscribe(typeof(WorkitemStateChangeCollection), OnWorkitemStateChanged);
        }

        private JiraServiceConfiguration GetValuesFromConfiguration()
        {
            jiraConfig = new JiraServiceConfiguration();

            ConfigurationReader.ReadConfigurationValues(jiraConfig, config);
            ConfigurationReader.ProcessMappingSettings(jiraConfig.ProjectMappings,
                config["ProjectMappings"],
                "JIRAProject",
                "VersionOneProject");
            ConfigurationReader.ProcessMappingSettings(jiraConfig.PriorityMappings,
                config["PriorityMappings"],
                "JIRAPriority",
                "VersionOnePriority");

            jiraConfig.OpenDefectFilter = GetFilterFromConfiguration("CreateDefectFilter");
            jiraConfig.OpenStoryFilter = GetFilterFromConfiguration("CreateStoryFilter");

            return jiraConfig;
        }

        private JiraFilter GetFilterFromConfiguration(string nodeName)
        {
            var node = config[nodeName];

            if (node == null)
            {
                throw new JiraConfigurationException("Can't read filter information");
            }

            var idAttribute = node.Attributes["id"];
            var id = idAttribute != null ? idAttribute.Value : string.Empty;

            var disabledAttribute = node.Attributes["disabled"];
            var disabled = disabledAttribute != null && disabledAttribute.Value == "1";

            return new JiraFilter(id, !disabled);
        }

        /// <summary>
        /// Timer interval on which to poll JIRA. See app config file for time in milliseconds.
        /// </summary>
        /// <param name="pubobj">Not used</param>
        private void OnInterval(object pubobj)
        {
            logger.Log(LogMessage.SeverityType.Info, "Starting processing...");
            IList<Workitem> workitems = new List<Workitem>();

            try
            {
                logger.Log(LogMessage.SeverityType.Info, "Getting issues from JIRA.");

                if (jiraConfig.OpenDefectFilter.Enabled)
                {
                    var bugs = jiraProcessor.GetIssues<Defect>(jiraConfig.OpenDefectFilter.Id);

                    if (bugs.Count > 0)
                    {
                        logger.Log(string.Format("Found {0} defects in JIRA to create in VersionOne.", bugs.Count));
                    }

                    foreach (var bug in bugs)
                    {
                        workitems.Add(bug);
                    }
                }

                if (jiraConfig.OpenStoryFilter.Enabled)
                {
                    var stories = jiraProcessor.GetIssues<Story>(jiraConfig.OpenStoryFilter.Id);

                    if (stories.Count > 0)
                    {
                        logger.Log(string.Format("Found {0} stories in JIRA to create in VersionOne.", stories.Count));
                    }

                    foreach (var story in stories)
                    {
                        workitems.Add(story);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Log(LogMessage.SeverityType.Error, string.Format("Error getting Issues from JIRA: {0}", ex.Message));
                return;
            }

            logger.Log(LogMessage.SeverityType.Info, "Checking JIRA issues for duplicates.");
            workitems = workitems.Distinct().ToList();

            // Create Workitem in V1 
            foreach (var item in workitems)
            {
                item.ExternalSystemName = jiraConfig.SourceFieldValue;
                eventManager.Publish(item);
            }

            // Query VersionOne for Closed defects with a JIRA Source Id
            var source = new ClosedWorkitemsSource(jiraConfig.SourceFieldValue, VersionOneProcessor.PrimaryWorkitemType);
            eventManager.Publish(source);

            logger.Log(LogMessage.SeverityType.Info, "Processing finished.");
        }

        /// <summary>
        /// A Defect or Story was created in V1 that corresponds to an Issue in JIRA. 
        /// We update the Issue in JIRA to reflect that.
        /// </summary>
        /// <param name="pubobj">WorkitemCreationResult of created defect.</param>
        private void OnWorkitemCreated(object pubobj)
        {
            var creationResult = pubobj as WorkitemCreationResult;

            if (creationResult != null)
            {
                jiraProcessor.OnWorkitemCreated(creationResult);
            }
        }

        private void OnWorkitemStateChanged(object pubobj)
        {
            var stateChangeCollection = pubobj as WorkitemStateChangeCollection;

            if (stateChangeCollection == null)
            {
                return;
            }

            foreach (var stateChangeResult in stateChangeCollection)
            {
                stateChangeResult.ChangesProcessed = true;

                if (!jiraProcessor.OnWorkitemStateChanged(stateChangeResult))
                {
                    stateChangeResult.ChangesProcessed = false;
                }
            }
        }

        public void RegisterComponents(IKernel container)
        {
            var connector = new JiraConnectorFactory(JiraConnectorType.Rest).Create(jiraConfig.Url, jiraConfig.UserName, jiraConfig.Password);

            container.Rebind<IEventManager>().ToConstant(eventManager);
            container.Rebind<ILogger>().ToConstant(logger);

            container.Bind<IJiraConnector>().ToConstant(connector);
            container.Bind<JiraServiceConfiguration>().ToConstant(jiraConfig);
            container.Bind<IJiraIssueProcessor>().To<JiraIssueReaderUpdater>();
            container.Bind<StartupChecker>().To<StartupChecker>();

            startupChecker = container.Get<StartupChecker>();
            jiraProcessor = container.Get<IJiraIssueProcessor>();
        }
    }
}