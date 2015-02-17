/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
namespace VersionOne.ServiceHost.WorkitemServices {
    public class Story : Workitem {
        public Story(string title, string description, string project, string owners): base(title, description, project, owners) {}

        public Story() {}

        public override string Type { get { return "Story"; } }
    }
}