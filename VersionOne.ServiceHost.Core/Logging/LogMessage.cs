/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;

namespace VersionOne.ServiceHost.Core.Logging {
    public class LogMessage {
        public enum SeverityType {
            Debug,
            Info,
            Warning,
            Error
        }

        public readonly SeverityType Severity;
        public readonly string Message;
        public readonly Exception Exception;
        public readonly DateTime Stamp;

        public LogMessage(SeverityType severity, string message, Exception exception) {
            Severity = severity;
            Message = message;
            Exception = exception;
            Stamp = DateTime.Now;
        }
    }
}