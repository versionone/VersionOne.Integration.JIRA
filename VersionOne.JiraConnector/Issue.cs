/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
namespace VersionOne.JiraConnector {
    public class Issue {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Project { get; set; }
        public string IssueType { get; set; }
        public string Assignee { get; set; }
        public string Priority { get; set; }

        public override string ToString() {
            return string.Format("[{0}]: {1}", Key, Summary);
        }
    }
}