/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;

namespace VersionOne.JiraConnector
{
    // TODO impl IDisposable when login token in SOAP connector is properly encapsulated?
    public interface IJiraConnector
    {
        bool Validate();
        void Login();
        void Logout();
        Issue[] GetIssuesFromFilter(string issueFilterId);
        Issue UpdateIssue(string issueKey, string fieldName, string fieldValue);
        IList<Item> GetPriorities();
        IList<Item> GetProjects();
        void AddComment(string issueKey, string comment);
        void ProgressWorkflow(string issueKey, string action, string assignee);
        IEnumerable<Item> GetAvailableActions(string issueId);
        IEnumerable<Item> GetCustomFields();
    }
}