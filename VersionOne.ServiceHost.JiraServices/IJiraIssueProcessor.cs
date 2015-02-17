/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;
using VersionOne.ServiceHost.WorkitemServices;

namespace VersionOne.ServiceHost.JiraServices {
    public interface IJiraIssueProcessor {
        IList<Workitem> GetIssues<T>(string filterId) where T : Workitem, new();
        void OnWorkitemCreated(WorkitemCreationResult createResult);
        bool OnWorkitemStateChanged(WorkitemStateChangeResult stateChangeResult);
    }
}