using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.ServiceHost.Core.Configuration;
using VersionOne.ServiceHost.JiraServices.StartupValidation;

namespace VersionOne.ServiceHost.JiraServices.Tests
{
    [TestClass]
    public class MappingValidatorTester : BaseJiraTester
    {
        [TestMethod]
        public void Validate()
        {
            var mapping = new Dictionary<MappingInfo, MappingInfo> {
                {new MappingInfo("Scope:0", "Name"), new MappingInfo("0", "Name")} ,
                {new MappingInfo("Scope:1", "Name 1"), new MappingInfo("1", "Name 1")} ,
            };
            var validator = new MappingValidator(mapping, "Tester") { JiraConnector = ConnectorMock, Logger = LoggerMock }; ;

            Assert.IsTrue(validator.Validate(), "Incorrect validator processing.");
        }

        [TestMethod]
        public void ValidateWithEmptyName()
        {
            var mapping = new Dictionary<MappingInfo, MappingInfo> {
                {new MappingInfo("Scope:0", string.Empty), new MappingInfo("0", string.Empty)} ,
                {new MappingInfo("Scope:1", string.Empty), new MappingInfo("1", string.Empty)} ,
            };
            var validator = new MappingValidator(mapping, "Tester") { JiraConnector = ConnectorMock, Logger = LoggerMock }; ;

            Assert.IsTrue(validator.Validate(), "Incorrect validator processing.");
        }

        [TestMethod]
        public void ValidateWithEmptyId()
        {
            var mapping = new Dictionary<MappingInfo, MappingInfo> {
                {new MappingInfo(string.Empty, "Name"), new MappingInfo(string.Empty, "Name")} ,
                {new MappingInfo(string.Empty, "Name 1"), new MappingInfo(string.Empty, "Name 1")} ,
            };
            var validator = new MappingValidator(mapping, "Tester") { JiraConnector = ConnectorMock, Logger = LoggerMock }; ;

            Assert.IsTrue(validator.Validate(), "Incorrect validator processing.");
        }

        [TestMethod]
        public void ValidateWithEmptyIdAndName1()
        {
            var mapping = new Dictionary<MappingInfo, MappingInfo> {
                {new MappingInfo(string.Empty, string.Empty), new MappingInfo(string.Empty, "Name")} ,
            };
            var validator = new MappingValidator(mapping, "Tester") { JiraConnector = ConnectorMock, Logger = LoggerMock }; ;

            Assert.IsFalse(validator.Validate(), "Incorrect validator processing.");
        }

        [TestMethod]
        public void ValidateWithEmptyIdAndName2()
        {
            var mapping = new Dictionary<MappingInfo, MappingInfo> {
                {new MappingInfo("Scope:0", "Name"), new MappingInfo(string.Empty, string.Empty)} ,
                {new MappingInfo("Scope:1", "Name 1"), new MappingInfo(string.Empty, string.Empty)} ,
            };
            var validator = new MappingValidator(mapping, "Tester") { JiraConnector = ConnectorMock, Logger = LoggerMock }; ;

            Assert.IsFalse(validator.Validate(), "Incorrect validator processing.");
        }
    }
}