/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
namespace VersionOne.JiraConnector.Exceptions {
    public class JiraLoginException : JiraException {
        public JiraLoginException() : base("Could not login with provided credentials", null) { }
    }
}