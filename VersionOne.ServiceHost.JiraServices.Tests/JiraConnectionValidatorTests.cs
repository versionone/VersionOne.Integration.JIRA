using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using VersionOne.JiraConnector.Exceptions;
using VersionOne.ServiceHost.JiraServices.StartupValidation;

namespace VersionOne.ServiceHost.Tests.WorkitemServices.Jira.StartupValidation {

    [TestClass]
    public class JiraConnectionValidatorTester : BaseJiraTester {

        [TestMethod]
        public void ValidConnection() {
            var validator = new JiraConnectionValidator { JiraConnector = ConnectorMock, Logger = LoggerMock};

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();
            Assert.IsTrue(result, "Connection is not valid.");
        }

        [TestMethod]
        public void InvalidConnection() {
            var validator = new JiraConnectionValidator { JiraConnector = ConnectorMock, Logger = LoggerMock};

            Expect.Call(ConnectorMock.Login).Throw(new Exception());

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();
            Assert.IsFalse(result, "Connection is not valid.");
        }

        [TestMethod]
        public void LoginFailure() {
            var validator = new JiraConnectionValidator { JiraConnector = ConnectorMock, Logger = LoggerMock};

            Expect.Call(ConnectorMock.Login).Throw(new JiraLoginException());

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();
            Assert.IsFalse(result, "Connection is not valid.");
        }
    }
}