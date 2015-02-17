using VersionOne.JiraConnector;
using System.Collections.Generic;

namespace VersionOne.ServiceHost.ConfigurationTool.DL {
    // TODO Do we need this class? It is small excerpt from JiraConnector project
    public class JiraConnector {
        private readonly IJiraConnector connector;
        
        public JiraConnector(string url, string username, string password) {
            connector = new JiraConnectorFactory(JiraConnectorType.Soap).Create(url, username, password);
        }

        public void Login() {
            connector.Login();
        }

        public void Logout() {
            connector.Logout();
        }

        public IList<Item> GetPriorities() {
            return connector.GetPriorities();
        }
    }
}