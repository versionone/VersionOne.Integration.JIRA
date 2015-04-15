/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;
using VersionOne.JiraConnector.Rest;
using VersionOne.JiraConnector.Soap;

namespace VersionOne.JiraConnector
{
    public class JiraConnectorFactory
    {
        public readonly JiraConnectorType ConnectorType;

        public JiraConnectorFactory(JiraConnectorType connectorType)
        {
            ConnectorType = connectorType;
        }

        public IJiraConnector Create(string url, string username, string password)
        {
            switch (ConnectorType)
            {
                case JiraConnectorType.Soap:
                    return new JiraSoapProxy(url, username, password);

                case JiraConnectorType.Rest:
                    return new JiraRestProxy(url, username, password);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}