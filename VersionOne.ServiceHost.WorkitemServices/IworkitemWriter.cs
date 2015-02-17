/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
namespace VersionOne.ServiceHost.WorkitemServices {
    public interface IWorkitemWriter {
        WorkitemCreationResult CreateWorkitem(Workitem item);
        WorkitemCreationResult CreateWorkitem(Workitem toSendToV1, ServerConnector.Entities.Workitem closedDuplicate);
    }
}