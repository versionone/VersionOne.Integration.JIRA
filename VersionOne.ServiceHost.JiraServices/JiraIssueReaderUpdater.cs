/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;
using System.Collections.Generic;
using System.Linq;
using VersionOne.JiraConnector;
using VersionOne.JiraConnector.Exceptions;
using VersionOne.ServiceHost.Core.Configuration;
using VersionOne.ServiceHost.Core.Logging;
using VersionOne.ServiceHost.WorkitemServices;

namespace VersionOne.ServiceHost.JiraServices {
    public class JiraIssueReaderUpdater : IJiraIssueProcessor {
        private readonly JiraServiceConfiguration configuration;
        private readonly ILogger logger;
        private readonly IJiraConnector connector;

        public JiraIssueReaderUpdater(JiraServiceConfiguration config, ILogger logger, IJiraConnector connector) {
            configuration = config;
            this.logger = logger;
            this.connector = connector;
        }

        public IList<Workitem> GetIssues<T>(string filterId) where T : Workitem, new() {
            connector.Login();
            var remoteIssues = connector.GetIssuesFromFilter(filterId);
            var items = new List<Workitem>();

            foreach (var issue in remoteIssues) {
                var projectMapping = ResolveVersionOneProjectMapping(issue.Project);
                var priorityMapping = ResolveVersionOnePriorityMapping(issue.Priority);
                var description = string.IsNullOrEmpty(issue.Description)
                                      ? issue.Description
                                      : issue.Description.Replace("\n", "<br/>");

                var item = new T {
                    Title = issue.Summary,
                    Project = projectMapping.Name,
                    ExternalId = issue.Key,
                    ProjectId = projectMapping.Id,
                    Description = description,
                    Owners = issue.Assignee,
                };

                if (!string.IsNullOrEmpty(configuration.UrlTemplateToIssue) &&
                    !string.IsNullOrEmpty(configuration.UrlTitleToIssue)) {
                    item.ExternalLink = new UrlToExternalSystem(configuration.UrlTemplateToIssue.Replace("#key#", issue.Key), configuration.UrlTitleToIssue);
                }

                if (priorityMapping != null) {
                    item.Priority = priorityMapping.Id;
                }

                items.Add(item);
            }

            connector.Logout();
            return items;
        }

        ///<summary>
        ///  A Workitem has been created in VersionOne in response to an Issue in JIRA.
        ///  We must update the Issue in JIRA to reflect the Workitem creation in VersionOne.
        ///  That reflection may be manifest by...
        ///  1) Updating a field (probably a custom field) to some value.
        ///  2) Progressing the workflow to another status.
        ///  One of these updates should keep the Issue from appearing in the new Issues filter again.
        ///</summary>
        ///<param name = "createdResult">Everything we need to know about the Workitem created in VersionOne.</param>
        public void OnWorkitemCreated(WorkitemCreationResult createdResult) {
            var issueId = createdResult.Source.ExternalId;
            var fieldName = configuration.OnCreateFieldName;
            var fieldValue = configuration.OnCreateFieldValue;
            var workflowId = configuration.ProgressWorkflow;
            var messages = createdResult.Messages;

            UpdateJiraIssue(issueId, fieldName, fieldValue, messages, workflowId, null);

            if(!string.IsNullOrEmpty(configuration.WorkitemLinkField)) {
                connector.Login();

                logger.Log(LogMessage.SeverityType.Info, string.Format("Updating field {0} in JIRA issue {1}", configuration.WorkitemLinkField, issueId));
                connector.UpdateIssue(issueId, configuration.WorkitemLinkField, createdResult.Permalink);

                connector.Logout();
            }
        }

        ///<summary>
        ///  A Workitem in VersionOne that was created as a result of an Issue in JIRA has changed
        ///  state. We must now reflect that change of state in the Issue in JIRA. We can relfect
        ///  that change in one of two ways:
        ///  1) Updating a field (probably a custom field) to some value.
        ///  2) Progressing the workflow to another status.
        ///</summary>
        ///<param name = "stateChangeResult">Tells us what Workitem state changed and what Issue to update.</param>
        public bool OnWorkitemStateChanged(WorkitemStateChangeResult stateChangeResult) {
            var issueId = stateChangeResult.ExternalId;
            var fieldName = configuration.OnStateChangeFieldName;
            var fieldValue = configuration.OnStateChangeFieldValue;
            var workflowId = configuration.ProgressWorkflowStateChanged;
            var messages = stateChangeResult.Messages;
            var assignee = configuration.AssigneeStateChanged;

            return UpdateJiraIssue(issueId, fieldName, fieldValue, messages, workflowId, assignee);
        }

        private bool UpdateJiraIssue(string issueId, string fieldName, string fieldValue, ICollection<string> messages, string workflowId, string assignee) {
            connector.Login();

            if(!string.IsNullOrEmpty(fieldName)) {
                try {
                    logger.Log(LogMessage.SeverityType.Info, string.Format("Updating JIRA field {0} in issue {1}", fieldName, issueId));
                    connector.UpdateIssue(issueId, fieldName, fieldValue);
                } catch(JiraException ex) {
                    logger.Log(LogMessage.SeverityType.Error, string.Format("Error updating {0} '{1}' to '{2}':\r\n{3}", issueId, fieldName, fieldValue, ex.Message));
                    connector.Logout();
                    return false;
                } catch(Exception ex) {
                    logger.Log(LogMessage.SeverityType.Error, string.Format("Error updating {0} '{1}' to '{2}':\r\n{3}", issueId, fieldName, fieldValue, ex));
                    connector.Logout();
                    return false;
                }
            }

            if(messages.Count > 0) {
                logger.Log(LogMessage.SeverityType.Info, string.Format("Adding comments to JIRA issue {0}", issueId));
            }

            foreach(var message in messages) {
                try {
                    connector.AddComment(issueId, message);
                } catch(Exception ex) {
                    logger.Log(LogMessage.SeverityType.Error, string.Format("Error during adding comment {0} to JIRA issue {1}:\r\n{2}", message, issueId, ex));
                }
            }

            if(!string.IsNullOrEmpty(workflowId) && IsActionAvailable(workflowId, issueId)) {
                logger.Log(LogMessage.SeverityType.Info, string.Format("Processing workflow {0} for JIRA issue {1}", workflowId, issueId));

                try {
                    connector.ProgressWorkflow(issueId, workflowId, assignee);
                } catch(Exception ex) {
                    logger.Log(LogMessage.SeverityType.Error, string.Format("Error during processing workflow {0} for JIRA issue {1}:\r\n{2}", workflowId, issueId, ex));
                    connector.Logout();
                    return false;
                }
            }

            connector.Logout();

            return true;
        }

        private MappingInfo ResolveVersionOneProjectMapping(string jiraProject) {
            foreach (var mapping in configuration.ProjectMappings.Where(mapping => mapping.Key.Name.Equals(jiraProject))) {
                return mapping.Value;
            }

            return new MappingInfo(null, jiraProject);
        }

        // TODO check if not found mapping causes the method to return null
        private MappingInfo ResolveVersionOnePriorityMapping(string jiraPriorityId) {
            return configuration.PriorityMappings.FirstOrDefault(x => x.Key.Id.Equals(jiraPriorityId)).Value;
        }

        private bool IsActionAvailable(string workflowId, string issueId) {
            logger.Log(LogMessage.SeverityType.Debug, string.Format("Checking if workflow {0} is available for issue {1}", workflowId, issueId));

            try {
                var actions = connector.GetAvailableActions(issueId).ToList();
                var actionIds = actions.Select(x => x.Id).ToList();

                if(actionIds.Contains(workflowId)) {
                    logger.Log(LogMessage.SeverityType.Debug, string.Format("Issue {0} can be processed to workflow {1}", issueId, workflowId));
                    return true;
                }

                logger.Log(LogMessage.SeverityType.Debug, string.Format("Cannot process issue {0} to state {1}. Available states are: {2}",
                        issueId, workflowId, string.Join(", ", actions.Select(x => x.ToString()).ToArray())));
            } catch(Exception ex) {
                logger.Log(LogMessage.SeverityType.Debug, string.Format("Error getting available actions for issue {0}:\r\n{1}", issueId, ex));
            }

            return false;
        }
    }
}