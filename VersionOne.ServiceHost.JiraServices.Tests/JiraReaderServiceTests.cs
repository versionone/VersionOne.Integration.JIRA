using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using VersionOne.JiraConnector;
using VersionOne.JiraConnector.Exceptions;
using VersionOne.ServiceHost.WorkitemServices;

namespace VersionOne.ServiceHost.JiraServices.Tests
{
    [TestClass]
    public class JiraReaderServiceTester : BaseJiraTester
    {
        private const string ExternalId = "external id";

        private JiraIssueReaderUpdater reader;
        private JiraServiceConfiguration config;

        [TestInitialize]
        public override void SetUp()
        {
            base.SetUp();

            config = new JiraServiceConfiguration
            {
                OnCreateFieldName = "oncreate_field_name",
                OnCreateFieldValue = "oncreate_field_value",
                OnStateChangeFieldName = "onchange_field_name",
                OnStateChangeFieldValue = "onchange_field_value",
                ProgressWorkflow = "workflow 1",
                WorkitemLinkField = "LinkField",
                ProgressWorkflowStateChanged = "workflow 2",
                AssigneeStateChanged = "-1",
                Url = Url,
                UserName = Username,
                Password = Password,
            };
            reader = new JiraIssueReaderUpdater(config, LoggerMock, ConnectorMock);
        }

        [TestMethod]
        public void OnWorkitemCreated()
        {
            var workitem = new Story("Title", "description", "project", "owners");
            var workitemResult = new WorkitemCreationResult(workitem)
            {
                Source = { ExternalId = ExternalId, },
                Permalink = "link",
            };
            workitemResult.Messages.Add("external id");

            FullUpdateJiraIssue(ExternalId, config.OnCreateFieldName, config.OnCreateFieldValue, workitemResult.Messages, config.ProgressWorkflow, null);
            UpdateWorkitemLinkInJira(workitemResult);

            Repository.ReplayAll();
            reader.OnWorkitemCreated(workitemResult);
            Repository.VerifyAll();
        }

        private void UpdateWorkitemLinkInJira(WorkitemCreationResult workitemResult)
        {
            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.UpdateIssue(workitemResult.Source.ExternalId, config.WorkitemLinkField, workitemResult.Permalink)).Return(null);
            Expect.Call(ConnectorMock.Logout);
        }

        [TestMethod]
        public void OnWorkitemStateChanged()
        {
            const string workitemId = "D-00001";
            var workitemResult = new WorkitemStateChangeResult(ExternalId, workitemId);
            workitemResult.Messages.Add("message 1");

            FullUpdateJiraIssue(ExternalId, config.OnStateChangeFieldName, config.OnStateChangeFieldValue,
                                workitemResult.Messages, config.ProgressWorkflowStateChanged, config.AssigneeStateChanged);

            Repository.ReplayAll();
            reader.OnWorkitemStateChanged(workitemResult);
            Repository.VerifyAll();
        }

        private void FullUpdateJiraIssue(string externalId, string fieldName, string fieldValue, List<string> messages, string workflowId, string assignee)
        {
            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.UpdateIssue(externalId, fieldName, fieldValue)).Return(null);
            Expect.Call(() => ConnectorMock.AddComment(externalId, messages[0])).Repeat.Once();
            Expect.Call(ConnectorMock.GetAvailableActions(externalId)).Return(new List<Item> { new Item(workflowId, "Name") });
            Expect.Call(() => ConnectorMock.ProgressWorkflow(externalId, workflowId, assignee));
            Expect.Call(ConnectorMock.Logout);
        }

        [TestMethod]
        public void OnWorkitemStateChangedWithoutWorkflowProgress()
        {
            const string workitemId = "D-00001";
            var workitemResult = new WorkitemStateChangeResult(ExternalId, workitemId);
            workitemResult.Messages.Add("message 1");

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.UpdateIssue(ExternalId, config.OnStateChangeFieldName, config.OnStateChangeFieldValue)).Return(null);
            Expect.Call(() => ConnectorMock.AddComment(ExternalId, workitemResult.Messages[0])).Repeat.Once();
            Expect.Call(ConnectorMock.GetAvailableActions(ExternalId)).Return(new List<Item>());
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            reader.OnWorkitemStateChanged(workitemResult);
            Repository.VerifyAll();
        }

        [TestMethod]
        public void OnWorkitemStateChangedWithEmptyData()
        {
            const string workitemId = "D-00001";
            var workitemResult = new WorkitemStateChangeResult(ExternalId, workitemId);
            var localReader = new JiraIssueReaderUpdater(new JiraServiceConfiguration(), LoggerMock, ConnectorMock);

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.Logout);

            Repository.ReplayAll();
            localReader.OnWorkitemStateChanged(workitemResult);
            Repository.VerifyAll();
        }

        [TestMethod]
        public void OnWorkitemCreatedInsufficientPermissions()
        {
            var workitem = new Story("Title", "description", "project", "owners");
            var workitemResult = new WorkitemCreationResult(workitem)
            {
                Source = { ExternalId = ExternalId, },
                Permalink = "link",
            };
            workitemResult.Messages.Add("external id");

            Expect.Call(ConnectorMock.Login);
            Expect.Call(ConnectorMock.UpdateIssue(ExternalId, config.OnCreateFieldName, config.OnCreateFieldValue)).Throw(new JiraException("Can't update issue", new Exception()));
            Expect.Call(ConnectorMock.Logout);

            UpdateWorkitemLinkInJira(workitemResult);

            Repository.ReplayAll();
            reader.OnWorkitemCreated(workitemResult);
            Repository.VerifyAll();
        }
    }
}