/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using Ninject;

namespace VersionOne.ServiceHost.Core.Services {
    public interface IComponentProvider {
        void RegisterComponents(IKernel container);
    }
}