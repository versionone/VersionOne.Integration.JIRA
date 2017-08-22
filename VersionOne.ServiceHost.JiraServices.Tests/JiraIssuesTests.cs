using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using VersionOne.JiraConnector.Rest;

namespace VersionOne.ServiceHost.JiraServices.Tests
{
    [TestClass]
    public class JiraIssuesTests
    {
        private JiraIssues _jirraIssues;

        [TestInitialize]
        public virtual void SetUp()
        {
            var content = new JObject();
            content.Add("total", new JValue(10));
            
            var issues = new JArray();
            issues.Add(CreateIssue1());
            issues.Add(CreateIssue2());

            content.Add("issues", issues);
            _jirraIssues = new JiraIssues(content);
        }

        [TestMethod]
        public void WhenAddingInAllIssuesItShouldHaveATotalNumberOfIssuesFromServer()
        {
           Assert.AreEqual(10, _jirraIssues.TotalAvailableOnJiraServer);
        }

        [TestMethod]
        public void WhenAddingInAllIssuesTheyShouldBeRetrievable()
        {
            var issue2Found = false;

            var issue1 = _jirraIssues.Issues.Where(issue => issue.Id == "123");
            var issue2 = _jirraIssues.Issues.Where(issue => issue.Id == "987");
            
            Assert.AreEqual(1, issue1.Count());
            Assert.AreEqual(1, issue2.Count());
        }

        [TestMethod]
        public void AddingInAdditionalIssuesShouldPlaceThemInTheIssuesCollection()
        {
            var content = new JObject();
            var issues = new JArray();
            issues.Add(CreateIssue3());
            issues.Add(CreateIssue4());

            content.Add("issues", issues);
            _jirraIssues.AddIssues(content);

            var issue3 = _jirraIssues.Issues.Where(issue => issue.Id == "565");
            var issue4 = _jirraIssues.Issues.Where(issue => issue.Id == "784");

            Assert.AreEqual(1, issue3.Count());
            Assert.AreEqual(1, issue4.Count());
        }


        private JToken CreateIssue1()
        {
            var issue = new JObject
            {
                {"id", "123"},
                { "key", "Issue1"}
            };

            var fields = new JObject
            {
                {"summmary", "We have a problem Houston."},
                {
                    "description",
                    "There is a problem with the fetzer valve. Grab some 20 weight ball bearings and get over here."
                }
            };
            issue.Add("fields", fields);
            return issue;
        }

        private JToken CreateIssue2()
        {
            var issue = new JObject
            {
                {"id", "987"},
                { "key", "Issue2"}
            };

            var fields = new JObject
            {
                {"summmary", "Production is not stable."},
                {
                    "description",
                    "We need to rebuild the box that production sits on."
                }
            };

            issue.Add("fields", fields);
            return issue;
        }

        private JToken CreateIssue3()
        {
            var issue = new JObject
            {
                {"id", "565"},
                { "key", "Issue3"}
            };

            var fields = new JObject
            {
                {"summmary", "Wrong Turn"},
                {
                    "description",
                    "Should have turned left at Albuquerque."
                }
            };
            issue.Add("fields", fields);
            return issue;
        }

        private JToken CreateIssue4()
        {
            var issue = new JObject
            {
                {"id", "784"},
                { "key", "Issue4"}
            };

            var fields = new JObject
            {
                {"summmary", "Who's on first."},
                {
                    "description",
                    "What's on second."
                }
            };

            issue.Add("fields", fields);
            return issue;
        }
    }
}
