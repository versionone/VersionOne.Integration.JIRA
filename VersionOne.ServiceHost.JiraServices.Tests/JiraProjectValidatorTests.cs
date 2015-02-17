using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.JiraConnector;
using VersionOne.ServiceHost.JiraServices.StartupValidation;
using VersionOne.ServiceHost.Core.Configuration;
using Rhino.Mocks;

namespace VersionOne.ServiceHost.Tests.WorkitemServices.Jira.StartupValidation {

    [TestClass]
    public class JiraProjectValidatorTester : BaseJiraTester {

        [TestMethod]
        public void ProjectsExist() {
            var projects = new List<MappingInfo> {
                new MappingInfo("1", "Name 1"),
                new MappingInfo("2", "Name 2"),
            };
            var existingProjects = new List<Item> {
                new Item("1", "Name 1"),
                new Item("2", "Name 2"),
            };
            var validator = new JiraProjectValidator(projects) { JiraConnector = ConnectorMock, Logger = LoggerMock};;

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetProjects()).Return(existingProjects);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();

            Assert.IsTrue(result, "Incorrect processing projects.");
        }

        [TestMethod]
        public void ProjectsDoNotExist() {
            var projects = new List<MappingInfo> {
                new MappingInfo("1", "Name 1"),
                new MappingInfo("2", "Name 2"),
            };
            var existingProjects = new List<Item> {
                new Item("2", "Name 2"),
                new Item("3", "Name 3"),
            };
            var validator = new JiraProjectValidator(projects) { JiraConnector = ConnectorMock, Logger = LoggerMock};;

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.GetProjects()).Return(existingProjects);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            var result = validator.Validate();
            Repository.VerifyAll();

            Assert.IsFalse(result, "Incorrect processing projects.");
        }
    }
}