using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using VersionOne.ServiceHost.JiraServices;
using VersionOne.ServiceHost.JiraServices.StartupValidation;

namespace VersionOne.ServiceHost.Tests.WorkitemServices.Jira.StartupValidation {

    [TestClass]
    public class JiraFilterValidatorTester : BaseJiraTester {

        [TestMethod]
        public void FilterExists() {
            const string filterId = "1";
            var filter = new JiraFilter(filterId, true);
            var validator = new JiraFilterValidator(filter) { JiraConnector = ConnectorMock, Logger = LoggerMock};;

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetIssuesFromFilter(filterId)).Return(null);            
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();

            Assert.IsTrue(result, "Incorrect filter processing");
        }

        [TestMethod]
        public void FilterDoesNotExist() {
            const string filterId = "1";
            var filter = new JiraFilter(filterId, true);
            var validator = new JiraFilterValidator(filter) { JiraConnector = ConnectorMock, Logger = LoggerMock};;

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetIssuesFromFilter(filterId)).Throw(new Exception());

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();

            Assert.IsFalse(result, "Incorrect filter processing");
        }

        [TestMethod]
        public void FilterIsNull() {
            var validator = new JiraFilterValidator(null) { JiraConnector = ConnectorMock, Logger = LoggerMock};;

            Expect.Call(ConnectorMock.Login).Repeat.Never();
            Expect.Call(ConnectorMock.GetIssuesFromFilter(null)).IgnoreArguments().Repeat.Never();

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();

            Assert.IsFalse(result, "Incorrect filter processing");
        }

        [TestMethod]
        public void FilterDisabled() {
            const string filterId = "1";
            var filter = new JiraFilter(filterId, false);
            var validator = new JiraFilterValidator(filter) { JiraConnector = ConnectorMock, Logger = LoggerMock};;

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();

            Assert.IsTrue(result, "Incorrect filter processing");
        }
    }
}