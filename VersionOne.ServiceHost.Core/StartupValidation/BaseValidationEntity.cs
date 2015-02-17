/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using Ninject;
using VersionOne.ServiceHost.Core.Logging;

namespace VersionOne.ServiceHost.Core.StartupValidation {
    public class BaseValidationEntity : IBaseValidationEntity {
        [Inject]
        public ILogger Logger { get; set; }

        public bool TreatErrorsAsWarnings { get; set; }

        protected void Log(LogMessage.SeverityType severity, string message) {
            var resultingSeverity = TreatErrorsAsWarnings && severity == LogMessage.SeverityType.Error
                                        ? LogMessage.SeverityType.Warning
                                        : severity;
            Logger.Log(resultingSeverity, message);
        }
    }
}