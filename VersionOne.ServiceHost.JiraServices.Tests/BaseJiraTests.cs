using Rhino.Mocks;
using VersionOne.JiraConnector;
using VersionOne.ServiceHost.Core;
using VersionOne.ServiceHost.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.ServiceHost.Tests.WorkitemServices.Jira {

    [TestClass]
    public class BaseJiraTester {

        protected const string Url = "http://localhost/versionone";
        protected const string Username = "user";
        protected const string Password = "password";

        protected readonly MockRepository Repository = new MockRepository();
        protected ILogger LoggerMock;
        protected IJiraConnector ConnectorMock;

        [ClassInitialize]
        public virtual void SetUp() {
            ConnectorMock = Repository.StrictMock<IJiraConnector>();
            LoggerMock = Repository.Stub<ILogger>();
        }

        [ClassCleanup]
        public void TearDown() {
            Repository.BackToRecordAll();
        }
    }
}