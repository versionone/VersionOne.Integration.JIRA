using System;
using VersionOne.JiraConnector;
using VersionOne.ServiceHost.ConfigurationTool.Entities;

namespace VersionOne.ServiceHost.ConfigurationTool.DL {
    public class JiraConnectionValidator : IConnectionValidator {
        private readonly JiraServiceEntity entity;

        public JiraConnectionValidator(JiraServiceEntity entity) {
            this.entity = entity;
        }

        public bool Validate() {
            var proxy = new JiraConnectorFactory(JiraConnectorType.Soap).Create(entity.Url, entity.UserName, entity.Password);

            try {
                proxy.Login();
                proxy.Logout();
                return true;
            } catch(Exception) {
                // TODO too generic exception type, probably should be changed to JiraLoginException; but how do we handle cases with invalid URL?
                return false;
            }
        }
    }
}