/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;
using System.Collections.Generic;
using System.Linq;
using VersionOne.JiraConnector.Exceptions;
using System.Web.Services.Protocols;

namespace VersionOne.JiraConnector.Soap
{
    public class JiraSoapProxy : IJiraConnector
    {
        private readonly string url;
        private readonly string username;
        private readonly string password;

        private readonly JiraSoapService soapService;

        // TODO use State
        private string loginToken;

        public JiraSoapProxy(string url, string username, string password)
        {
            this.url = url;
            this.username = username;
            this.password = password;

            soapService = new JiraSoapService { Url = url };
        }

        public bool Validate()
        {
            try
            {
                Login();
                Logout();
                return true;
            }
            catch (Exception)
            {
                // TODO too generic exception type, probably should be changed to JiraLoginException; but how do we handle cases with invalid URL?
                return false;
            }
        }

        public void Login()
        {
            loginToken = soapService.login(username, password);

            if (string.IsNullOrEmpty(loginToken))
            {
                throw new JiraLoginException();
            }
        }

        public Issue[] GetIssuesFromFilter(string issueFilterId)
        {
            var remoteIssues = soapService.getIssuesFromFilter(loginToken, issueFilterId);
            return remoteIssues.Select(remoteIssue => CreateIssue(remoteIssue)).ToArray();
        }

        public Issue UpdateIssue(string issueKey, string fieldName, string fieldValue)
        {
            try
            {
                var remoteFieldValue = new RemoteFieldValue { id = fieldName, values = new[] { fieldValue } };
                return CreateIssue(soapService.updateIssue(loginToken, issueKey, new[] { remoteFieldValue }));
            }
            catch (SoapException ex)
            {
                ProcessException(ex);
                throw;
            }
        }

        public void AddComment(string issueKey, string comment)
        {
            var remoteComment = new RemoteComment { body = comment };
            soapService.addComment(loginToken, issueKey, remoteComment);
        }

        public void ProgressWorkflow(string issueKey, string action, string assignee)
        {
            if (assignee != null)
            {
                var assigneeField = new RemoteFieldValue { id = "assignee", values = new[] { assignee } };
                soapService.progressWorkflowAction(loginToken, issueKey, action, new[] { assigneeField });
            }
            else
            {
                soapService.progressWorkflowAction(loginToken, issueKey, action, new RemoteFieldValue[] { });
            }
        }

        private Issue CreateIssue(RemoteIssue remote)
        {
            var result = new Issue
            {
                Summary = remote.summary,
                Description = remote.description,
                Project = GetProjectNameFromKey(remote.project),
                IssueType = remote.type,
                Assignee = remote.assignee,
                Id = remote.id,
                Key = remote.key,
                Priority = remote.priority
            };

            return result;
        }

        private string GetProjectNameFromKey(string projectKey)
        {
            var remoteProject = soapService.getProjectByKey(loginToken, projectKey);
            return remoteProject.name;
        }

        public IList<Item> GetPriorities()
        {
            var remotePriorities = soapService.getPriorities(loginToken);
            return remotePriorities.Select(remotePriority => new Item(remotePriority.id, remotePriority.name)).ToList();
        }

        public IList<Item> GetProjects()
        {
            var remoteProjects = soapService.getProjects(loginToken);
            return remoteProjects.Select(remoteProject => new Item(remoteProject.id, remoteProject.name)).ToList();
        }

        public void Logout()
        {
            soapService.logout(loginToken);
            loginToken = null;
        }

        public IEnumerable<Item> GetAvailableActions(string issueId)
        {
            var remoteActions = soapService.getAvailableActions(loginToken, issueId);
            return remoteActions.Select(x => new Item(x.id, x.name)).ToList();
        }

        public IEnumerable<Item> GetCustomFields()
        {
            try
            {
                var removeFields = soapService.getCustomFields(loginToken);
                return removeFields.Select(removeField => new Item(removeField.id, removeField.name)).ToList();
            }
            catch (SoapException ex)
            {
                ProcessException(ex);
                throw;
            }
        }

        //TODO: if it's possible - find better way to process remote exception from JIRA
        private static void ProcessException(SoapException exception)
        {
            var remoteMessages = exception.Message.Split(':');
            var message = remoteMessages.Count() > 1 ? String.Join(" ", remoteMessages, 1, remoteMessages.Count() - 1) : exception.Message;

            if (exception.Message.Contains("RemotePermissionException"))
            {
                throw new JiraPermissionException(message.Trim(), exception);
            }

            if (exception.Message.Contains("RemoteValidationException"))
            {
                throw new JiraValidationException(message.Trim(), exception);
            }
        }
    }
}