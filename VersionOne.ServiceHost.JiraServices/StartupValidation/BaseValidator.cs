/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using Ninject;
using VersionOne.JiraConnector;
using VersionOne.ServiceHost.Core.StartupValidation;

namespace VersionOne.ServiceHost.JiraServices.StartupValidation {
    public abstract class BaseValidator : BaseValidationEntity, ISimpleValidator {
        [Inject]
        public IJiraConnector JiraConnector { get; set; }

        public abstract bool Validate();
    }
}