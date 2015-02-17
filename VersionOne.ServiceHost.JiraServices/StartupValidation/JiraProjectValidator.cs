/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;
using System.Linq;
using VersionOne.ServiceHost.Core.Configuration;
using VersionOne.ServiceHost.Core.Logging;

namespace VersionOne.ServiceHost.JiraServices.StartupValidation {
    public class JiraProjectValidator : BaseValidator {
        private readonly ICollection<MappingInfo> projects;

        public JiraProjectValidator(ICollection<MappingInfo> projects) {
            this.projects = projects;
        }

        public override bool Validate() {
            var result = true;
            Log(LogMessage.SeverityType.Info, "Checking JIRA projects.");

            JiraConnector.Login();
            var jiraProjects = JiraConnector.GetProjects();

            foreach (var project in projects.Where(project => !jiraProjects.Any(x => x.Name.Equals(project.Name)))) {
                Log(LogMessage.SeverityType.Error, string.Format("Cannot find JIRA project with name '{0}'.", project.Name));
                result = false;
            }

            JiraConnector.Logout();

            Log(LogMessage.SeverityType.Info, "JIRA projects are checked.");
            return result;
        }
    }
}