/*(c) Copyright 2012, VersionOne, Inc. All rights reserved. (c)*/
using System.Collections.Generic;
using System.Linq;
using VersionOne.ServiceHost.Core.Configuration;
using VersionOne.ServiceHost.Core.Logging;

namespace VersionOne.ServiceHost.JiraServices.StartupValidation {
    public class MappingValidator : BaseValidator {
        private readonly IDictionary<MappingInfo, MappingInfo> mappings;
        private readonly string mappingName;

        public MappingValidator(IDictionary<MappingInfo, MappingInfo> mappings, string mappingName) {
            this.mappings = mappings;
            this.mappingName = mappingName;
        }

        public override bool Validate() {
            Log(LogMessage.SeverityType.Info, string.Format("Checking JIRA {0} mappings.", mappingName));

            var emptyCounter = mappings.Count(IsMappingEmpty);

            if (emptyCounter > 0) {
                Log(LogMessage.SeverityType.Error, string.Format("Mapping contains {0} empty mapping(s).", emptyCounter));
            }
            
            Log(LogMessage.SeverityType.Info, string.Format("JIRA {0} mappings are checked.", mappingName));

            return emptyCounter == 0;
        }

        private static bool IsMappingEmpty(KeyValuePair<MappingInfo, MappingInfo> mapping) {
            return mapping.Key.IsNullOrEmpty() || mapping.Value.IsNullOrEmpty();
        }
    }
}