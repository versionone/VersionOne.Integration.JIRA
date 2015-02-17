/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;
using VersionOne.ServiceHost.Core.Logging;

namespace VersionOne.ServiceHost.JiraServices.StartupValidation {
    public class JiraFilterValidator : BaseValidator {
        private readonly JiraFilter filter;

        public JiraFilterValidator(JiraFilter filter) {
            this.filter = filter;
        }

        public override bool Validate() {
            Log(LogMessage.SeverityType.Info, "Checking JIRA filter.");

            if(filter == null) {
                Log(LogMessage.SeverityType.Error, "Filter is null.");
                return false;
            }

            if(!filter.Enabled) {
                Log(LogMessage.SeverityType.Debug, string.Format("Filter {0} disabled.", filter.Id));
                return true;
            }

            try {
                JiraConnector.Login();
                JiraConnector.GetIssuesFromFilter(filter.Id);
                JiraConnector.Logout();
            } catch(Exception) {
                Log(LogMessage.SeverityType.Error, string.Format("Can't find {0} filter.", filter.Id));
                return false;
            }

            Log(LogMessage.SeverityType.Info, "JIRA filter is checked.");

            return true;
        }
    }
}