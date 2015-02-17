/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;
using System.Linq;
using VersionOne.ServiceHost.Core.Logging;
using VersionOne.ServiceHost.Core.Configuration;

namespace VersionOne.ServiceHost.JiraServices.StartupValidation {
    public class JiraPriorityValidator : BaseValidator {
        private readonly ICollection<MappingInfo> priorities;

        public JiraPriorityValidator(ICollection<MappingInfo> priorities) {
            this.priorities = priorities;
        }

        public override bool Validate() {
            var result = true;
            Log(LogMessage.SeverityType.Info, "Checking JIRA priorities");

            JiraConnector.Login();
            var jiraPriorities = JiraConnector.GetPriorities();

            foreach (var priority in priorities.Where(priority => !jiraPriorities.Any(x => x.Id.Equals(priority.Id)))) {
                Log(LogMessage.SeverityType.Error, string.Format("Cannot find JIRA priority with identifier {0}", priority.Id));
                result = false;
            }

            JiraConnector.Logout();

            Log(LogMessage.SeverityType.Info, "JIRA priorities are checked");
            return result;
        }
    }
}