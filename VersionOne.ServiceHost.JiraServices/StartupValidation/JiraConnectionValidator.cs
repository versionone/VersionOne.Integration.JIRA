/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;
using VersionOne.JiraConnector.Exceptions;
using VersionOne.ServiceHost.Core.Logging;

namespace VersionOne.ServiceHost.JiraServices.StartupValidation {
    public class JiraConnectionValidator : BaseValidator {
        public override bool Validate() {
            try {
                JiraConnector.Login();
                JiraConnector.Logout();
            } catch(JiraLoginException) {
                Log(LogMessage.SeverityType.Error, "Incorrect credentials or JIRA URL.");
                return false;
            } catch(Exception ex) {
                Log(LogMessage.SeverityType.Error, "Incorrect credentials or JIRA URL. " + ex.Message);
                return false;
            }

            return true;
        }
    }
}