﻿/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System;

namespace VersionOne.ServerConnector {
    public class VersionOneException : Exception {
        public VersionOneException(string message) : base(message) { }
    }
}