using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using VersionOne.JiraConnector;
using VersionOne.ServiceHost.Core.Configuration;
using VersionOne.ServiceHost.JiraServices.StartupValidation;

namespace VersionOne.ServiceHost.JiraServices.Tests
{
    [TestClass]
    public class JiraPriorityValidatorTester : BaseJiraTester
    {
        [TestMethod]
        public void PriorityExist()
        {
            var priorities = new List<MappingInfo> {
                new MappingInfo("1", "Name 1"),
                new MappingInfo("2", "Name 2"),
            };
            var existPriorities = new List<Item> {
                new Item("1", "Name 1"),
                new Item("2", "Name 2"),
            };
            var validator = new JiraPriorityValidator(priorities) { JiraConnector = ConnectorMock, Logger = LoggerMock }; ;

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetPriorities()).Return(existPriorities);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();

            Assert.IsTrue(result, "Incorrect processing priorities.");
        }

        [TestMethod]
        public void PriorityDoesntExist()
        {
            var priorities = new List<MappingInfo> {
                new MappingInfo("1", "Name 1"),
                new MappingInfo("2", "Name 2"),
            };
            var existPriorities = new List<Item> {
                new Item("2", "Name 2"),
                new Item("3", "Name 3"),
            };
            var validator = new JiraPriorityValidator(priorities) { JiraConnector = ConnectorMock, Logger = LoggerMock }; ;

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetPriorities()).Return(existPriorities);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();

            Assert.IsFalse(result, "Incorrect processing priorities.");
        }
    }
}