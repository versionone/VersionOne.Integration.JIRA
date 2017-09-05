using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace VersionOne.JiraConnector.Rest
{
    public class JiraIssues
    {
        public JiraIssues(dynamic responseContent)
        {
            Issues = ConvertToIssues(responseContent);
            TotalAvailableOnJiraServer = (int) responseContent.total;
        }

        public Issue[] Issues { get; private set; }
        public int TotalAvailableOnJiraServer { get; private set; }

        public void AddIssues(dynamic responseContent)
        {
            var allIssues = new List<Issue>();
            allIssues.AddRange(Issues);
            allIssues.AddRange(ConvertToIssues(responseContent));
            Issues = allIssues.ToArray();
        }

        private static Issue[] ConvertToIssues(dynamic responseContent)
        {
            return ((JArray) responseContent.issues).Select(CreateIssue).ToArray();
        }

        private static Issue CreateIssue(dynamic data)
        {
            return new Issue
            {
                Id = data.id,
                Key = data.key,
                Summary = data.fields.summary,
                Description = data.fields.description,
                Project = data.fields.project != null ? data.fields.project.name : string.Empty,
                IssueType = data.fields.issuetype != null ? data.fields.issuetype.name : string.Empty,
                Assignee = data.fields.assignee != null ? data.fields.assignee.name : string.Empty,
                Priority = data.fields.priority != null ? data.fields.priority.name : string.Empty
            };
        }
    }
}