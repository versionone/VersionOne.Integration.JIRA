using System;
using System.Xml.Serialization;
using VersionOne.ServiceHost.ConfigurationTool.Attributes;
using VersionOne.ServiceHost.ConfigurationTool.Validation;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities {
    public class JiraFilter {
        public const string DisabledProperty = "Disabled";
        public const string IdProperty = "Id";

        [HelpString(HelpResourceKey = "JiraFilterId")]
        [XmlAttribute("id")]
        [ConditionalNonEmptyStringValidator(DisabledProperty, false)]
        public string Id { get; set; }

        [HelpString(HelpResourceKey = "JiraFilterDisabled")]
        [XmlIgnore]
        public bool Disabled { get; set; }

        [XmlAttribute("disabled")]
        public int DisabledNumeric {
            get { return Convert.ToInt32(Disabled); }
            set { Disabled = Convert.ToBoolean(value); }
        }
    }
}