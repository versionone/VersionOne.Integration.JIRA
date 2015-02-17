/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;
using VersionOne.ServiceHost.Core.Utility;
using VersionOne.ServiceHost.Core.Configuration;

namespace VersionOne.ServiceHost.JiraServices {
    public class JiraServiceConfiguration {
        private readonly IDictionary<MappingInfo, MappingInfo> projectMappings = new Dictionary<MappingInfo, MappingInfo>();
        private readonly IDictionary<MappingInfo, MappingInfo> priorityMappings = new Dictionary<MappingInfo, MappingInfo>();

        [ConfigFileValue("JIRAUserName", null)]
        public string UserName;

        [ConfigFileValue("JIRAPassword", null)]
        public string Password;

        [ConfigFileValue("JIRAUrl", null)]
        public string Url;

        [ConfigFileValue("SourceFieldValue")]
        public string SourceFieldValue;

        [ConfigFileValue("CreateFieldId")]
        public string OnCreateFieldName;

        [ConfigFileValue("CreateFieldValue")]
        public string OnCreateFieldValue;

        [ConfigFileValue("CloseFieldId")]
        public string OnStateChangeFieldName;

        [ConfigFileValue("CloseFieldValue")]
        public string OnStateChangeFieldValue;

        [IgnoreConfigFieldAttribute]
        public JiraFilter OpenDefectFilter;

        [IgnoreConfigFieldAttribute]
        public JiraFilter OpenStoryFilter;

        [ConfigFileValue("ProgressWorkflow")]
        public string ProgressWorkflow;

        [ConfigFileValue("ProgressWorkflowClosed")]
        public string ProgressWorkflowStateChanged;

        [ConfigFileValue("AssigneeStateChanged")]
        public string AssigneeStateChanged;

        [ConfigFileValue("WorkitemLinkFieldId")]
        public string WorkitemLinkField;

        [ConfigFileValue("JIRAIssueUrlTemplate")]
        public string UrlTemplateToIssue;

        [ConfigFileValue("JIRAIssueUrlTitle")]
        public string UrlTitleToIssue;

        public IDictionary<MappingInfo, MappingInfo> ProjectMappings {
            get { return projectMappings; }
        }

        public IDictionary<MappingInfo, MappingInfo> PriorityMappings {
            get { return priorityMappings; }
        }
    }
}