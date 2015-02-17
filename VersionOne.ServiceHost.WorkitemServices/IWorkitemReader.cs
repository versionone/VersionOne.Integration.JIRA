/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;

namespace VersionOne.ServiceHost.WorkitemServices {
    public interface IWorkitemReader {
        IList<ServerConnector.Entities.Workitem> GetDuplicates(Workitem item);
    }
}