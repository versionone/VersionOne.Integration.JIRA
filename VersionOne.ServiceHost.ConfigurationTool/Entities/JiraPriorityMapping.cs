using System.Xml.Serialization;
using VersionOne.ServiceHost.ConfigurationTool.Validation;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    public class JiraPriorityMapping
    {
        public const string VersionOnePriorityNameProperty = "VersionOnePriorityName";
        public const string VersionOnePriorityIdProperty = "VersionOnePriorityId";
        public const string JiraPriorityNameProperty = "JiraPriorityName";
        public const string JiraPriorityIdProperty = "JiraPriorityId";

        public JiraPriorityMapping()
        {
            JiraPriority = new Mapping();
            VersionOnePriority = new Mapping();
        }

        [XmlElement("JIRAPriority")]
        public Mapping JiraPriority { get; set; }

        public Mapping VersionOnePriority { get; set; }

        [XmlIgnore]
        public string VersionOnePriorityName
        {
            get { return VersionOnePriority.Name; }
            set { VersionOnePriority.Name = value; }
        }

        [XmlIgnore]
        [NonEmptyStringValidator]
        public string VersionOnePriorityId
        {
            get { return VersionOnePriority.Id; }
            set { VersionOnePriority.Id = value; }
        }

        [XmlIgnore]
        public string JiraPriorityName
        {
            get { return JiraPriority.Name; }
            set { JiraPriority.Name = value; }
        }

        [XmlIgnore]
        [NonEmptyStringValidator]
        public string JiraPriorityId
        {
            get { return JiraPriority.Id; }
            set { JiraPriority.Id = value; }
        }
    }
}