/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using VersionOne.SDK.APIClient;

namespace VersionOne.ServerConnector.Filters {
    public interface IFilter {
        GroupFilterTerm GetFilter(IAssetType type);
    }
}