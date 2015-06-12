/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;
using VersionOne.ServiceHost.ServerConnector.StartupValidation;
using VersionOne.ServiceHost.Core;
using VersionOne.ServiceHost.Core.StartupValidation;
using VersionOne.ServiceHost.Eventing;

namespace VersionOne.ServiceHost.JiraServices.StartupValidation {
    public class StartupChecker : StartupCheckerBase {
        private readonly JiraServiceConfiguration config;

        public StartupChecker(JiraServiceConfiguration config, IEventManager eventManager, IDependencyInjector dependencyInjector) : base(eventManager, dependencyInjector) {
            this.config = config;            
        }

        protected override IEnumerable<IValidationStep> CreateValidators() {
            return new List<IValidationStep> {
                new ValidationSimpleStep(new V1ConnectionValidator(), null),
                new ValidationSimpleStep(new JiraConnectionValidator(), null),
                new ValidationSimpleStep(new MappingValidator(config.ProjectMappings, "Project"), null),
                new ValidationSimpleStep(new MappingValidator(config.PriorityMappings, "Priority"), null),
                new ValidationSimpleStep(new V1ProjectsValidator(config.ProjectMappings.Values), null),
                new LooseValidationSimpleStep(new JiraCustomFieldValidator(config.OnCreateFieldName, config.OnStateChangeFieldName, config.WorkitemLinkField), null),
                new ValidationSimpleStep(new JiraFilterValidator(config.OpenDefectFilter), null),
                new ValidationSimpleStep(new JiraFilterValidator(config.OpenStoryFilter), null),
                new ValidationSimpleStep(new V1PriorityValidator(config.PriorityMappings.Values), null),
                new ValidationSimpleStep(new JiraPriorityValidator(config.PriorityMappings.Keys), null),
                new ValidationSimpleStep(new JiraProjectValidator(config.ProjectMappings.Keys), null),
            };            
        }
    }
}