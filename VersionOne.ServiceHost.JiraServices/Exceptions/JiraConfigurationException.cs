/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;

namespace VersionOne.ServiceHost.JiraServices.Exceptions {
    public class JiraConfigurationException : Exception {
        public JiraConfigurationException(string message) : base(message) { }
    }
}