using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using VersionOne.JiraConnector;
using VersionOne.ServiceHost.JiraServices;
using VersionOne.ServiceHost.WorkitemServices;

namespace VersionOne.ServiceHost.Tests.WorkitemServices.Jira {

    [TestClass]
    public class JiraProxyTester : BaseJiraTester {
        private JiraIssueReaderUpdater jiraComponent;

        [ClassInitialize]
        public override void SetUp() {
            base.SetUp();
            var config = new JiraServiceConfiguration { Url = Url, UserName = Username, Password = Password, };
            jiraComponent = new JiraIssueReaderUpdater(config, LoggerMock, ConnectorMock);
        }

        [TestMethod]
        public void GetIssues() {
            const string filterId = "FilterId";
            var remoteIssues = new[] {new Issue {Key = "Id1", Summary = "Name1"}, new Issue {Key = "Id2", Summary = "Name2"}};

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetIssuesFromFilter(filterId)).Return(remoteIssues);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            var items = jiraComponent.GetIssues<Defect>(filterId);

            Repository.VerifyAll();
            Assert.AreEqual(remoteIssues.Length, items.Count);

            //foreach(var issue in remoteIssues) {
            //    ListAssert.Contains(issue.Key, items.Select(x => x.ExternalId));
            //    ListAssert.Contains(issue.Summary, items.Select(x => x.Title));
            //}
        }
    }
}