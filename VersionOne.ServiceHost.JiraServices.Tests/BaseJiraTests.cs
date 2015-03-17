using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using VersionOne.JiraConnector;
using VersionOne.ServiceHost.Core.Logging;

namespace VersionOne.ServiceHost.JiraServices.Tests
{
    [TestClass]
    public class BaseJiraTester
    {
        protected const string Url = "http://localhost/versionone";
        protected const string Username = "user";
        protected const string Password = "password";

        protected readonly MockRepository Repository = new MockRepository();
        protected ILogger LoggerMock;
        protected IJiraConnector ConnectorMock;

        [TestInitialize]
        public virtual void SetUp()
        {
            ConnectorMock = Repository.StrictMock<IJiraConnector>();
            LoggerMock = Repository.Stub<ILogger>();
        }

        [TestCleanup]
        public void TearDown()
        {
            Repository.BackToRecordAll();
        }
    }
}