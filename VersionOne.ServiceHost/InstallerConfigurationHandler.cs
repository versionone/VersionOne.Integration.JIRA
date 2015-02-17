/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Configuration;
using System.Xml;
using VersionOne.ServiceHost.Core.Configuration;

namespace VersionOne.ServiceHost {
    public class InstallerConfigurationHandler : IConfigurationSectionHandler {
        public object Create(object parent, object configContext, XmlNode section) {
            return new InstallerConfiguration(section);
        }
    }
}