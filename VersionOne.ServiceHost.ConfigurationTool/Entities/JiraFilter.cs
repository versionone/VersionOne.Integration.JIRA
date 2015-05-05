using System;
using System.Xml.Serialization;
using VersionOne.ServiceHost.ConfigurationTool.Attributes;
using VersionOne.ServiceHost.ConfigurationTool.Validation;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    public class JiraFilter : BaseEntity
    {
        public const string IdProperty = "Id";

        private string id;

        [HelpString(HelpResourceKey = "JiraFilterId")]
        [XmlAttribute("id")]
        [ConditionalNonEmptyStringValidator(DisabledProperty, false)]
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        [HelpString(HelpResourceKey = "JiraFilterDisabled")]
        [XmlIgnore]
        public override bool Disabled
        {
            get { return disabled; }
            set
            {
                disabled = value;
                NotifyPropertyChanged();
            }
        }

        [XmlAttribute("disabled")]
        public int DisabledNumeric
        {
            get { return Convert.ToInt32(Disabled); }
            set { Disabled = Convert.ToBoolean(value); }
        }
    }
}