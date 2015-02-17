/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;
using System.Linq;
using VersionOne.JiraConnector;
using VersionOne.JiraConnector.Exceptions;
using VersionOne.ServiceHost.Core.Logging;
using System;

namespace VersionOne.ServiceHost.JiraServices.StartupValidation {
    public class JiraCustomFieldValidator : BaseValidator {
        private readonly string[] fields;

        public JiraCustomFieldValidator(params string[] fields) {
            this.fields = fields;
        }

        public override bool Validate() {
            var result = true;

            Log(LogMessage.SeverityType.Info, "Checking custom fields.");

            try {
                JiraConnector.Login();

                var customFields = JiraConnector.GetCustomFields().ToList();

                if (!customFields.Any()) {
                    Log(LogMessage.SeverityType.Error, "JIRA doesn't contain custom fields.");
                    return false;
                }

                foreach (var field in fields.Distinct()) {
                    if (string.IsNullOrEmpty(field)) {
                        Log(LogMessage.SeverityType.Debug, "At least one custom field id is empty.");
                        continue;
                    }

                    Log(LogMessage.SeverityType.Info, string.Format("Checking {0} field.", field));

                    if (!ValidateField(field, customFields)) {
                        result = false;
                    }
                }
            } catch (JiraPermissionException ex) {
                Log(LogMessage.SeverityType.Error, "You don't have permission to get custom fields: " + ex.Message);
                return false;
            } catch (Exception) {
                Log(LogMessage.SeverityType.Error, "Can't get custom field information.");
                return false;
            } finally {
                JiraConnector.Logout();
            }

            Log(LogMessage.SeverityType.Info, "All fields checked.");
            return result;
        }

        private bool ValidateField(string field, IEnumerable<Item> customFields) {
            if(!customFields.Any(x => x.Id.Equals(field))) {
                Log(LogMessage.SeverityType.Error, string.Format("Field {0} doesn't exist.", field));
                return false;
            }

            return true;
        }
    }
}