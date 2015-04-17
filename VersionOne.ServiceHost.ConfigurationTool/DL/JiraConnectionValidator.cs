using System;
using VersionOne.JiraConnector;
using VersionOne.ServiceHost.ConfigurationTool.Entities;

namespace VersionOne.ServiceHost.ConfigurationTool.DL
{
    public class JiraConnectionValidator : IConnectionValidator
    {
        private readonly JiraServiceEntity entity;

        public JiraConnectionValidator(JiraServiceEntity entity)
        {
            this.entity = entity;
        }

        public bool Validate()
        {
            var proxy = new JiraConnectorFactory(JiraConnectorType.Rest).Create(entity.Url, entity.UserName, entity.Password);
            return proxy.Validate();
        }
    }
}