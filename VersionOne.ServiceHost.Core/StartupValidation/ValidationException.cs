/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;

namespace VersionOne.ServiceHost.Core.StartupValidation {
    public class ValidationException : Exception {
        public ValidationException(string message) : base(message) {}
    }
}