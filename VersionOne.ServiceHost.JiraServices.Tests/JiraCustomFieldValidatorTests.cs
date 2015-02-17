using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using VersionOne.JiraConnector;
using VersionOne.JiraConnector.Exceptions;
using VersionOne.ServiceHost.JiraServices.StartupValidation;

namespace VersionOne.ServiceHost.Tests.WorkitemServices.Jira.StartupValidation {

    [TestClass]
    public class JiraCustomFieldValidatorTester : BaseJiraTester {

        [TestMethod]
        public void ExistingField() {
            var validator = new JiraCustomFieldValidator("ID_001", "ID_002") { JiraConnector = ConnectorMock, Logger = LoggerMock};;
            var existingFields = new List<Item> { new Item("ID_001", "field1"), new Item("ID_002", "field2") };

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetCustomFields()).Return(existingFields);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            Assert.IsTrue(validator.Validate());
            Repository.VerifyAll();
        }

        [TestMethod]
        public void NonExistingField() {
            var validator = new JiraCustomFieldValidator("ID_001", "ID_002") { JiraConnector = ConnectorMock, Logger = LoggerMock};;
            var existingFields = new List<Item> { new Item("ID_001", "field1") };

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetCustomFields()).Return(existingFields);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            Assert.IsFalse(validator.Validate());
            Repository.VerifyAll();            
        }

        [TestMethod]
        public void NoCustomFields() {
            var validator = new JiraCustomFieldValidator("ID_001", "ID_002") { JiraConnector = ConnectorMock, Logger = LoggerMock};;
            var existingFields = new List<Item>();

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetCustomFields()).Return(existingFields);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            Assert.IsFalse(validator.Validate());
            Repository.VerifyAll();
        }

        [TestMethod]
        public void EmptyField() {
            var validator = new JiraCustomFieldValidator("ID_001", string.Empty) { JiraConnector = ConnectorMock, Logger = LoggerMock};;
            var existingFields = new List<Item> { new Item("ID_001", "field1") };

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetCustomFields()).Return(existingFields);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            Assert.IsTrue(validator.Validate());
            Repository.VerifyAll();
        }

        [TestMethod]
        public void InsufficientPermissions() {
            var validator = new JiraCustomFieldValidator("ID_001") { JiraConnector = ConnectorMock, Logger = LoggerMock};;

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetCustomFields()).Throw(new JiraPermissionException(null, null));
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            Assert.IsFalse(validator.Validate());
            Repository.VerifyAll();
        }

        [TestMethod]
        public void GenericFailure() {
            var validator = new JiraCustomFieldValidator("ID_001") { JiraConnector = ConnectorMock, Logger = LoggerMock};;

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetCustomFields()).Throw(new WebException(string.Empty, WebExceptionStatus.RequestProhibitedByProxy));
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            Assert.IsFalse(validator.Validate());
            Repository.VerifyAll();
        }
    }
}