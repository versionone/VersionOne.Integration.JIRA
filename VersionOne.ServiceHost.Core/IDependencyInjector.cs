/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
namespace VersionOne.ServiceHost.Core {
    public interface IDependencyInjector {
        void Inject(object consumer);
    }
}