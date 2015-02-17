using System.Xml.Serialization;
using VersionOne.ServiceHost.ConfigurationTool.Validation;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities {
    public class JiraProjectMapping {
        public const string VersionOneProjectNameProperty = "VersionOneProjectName";
        public const string VersionOneProjectTokenProperty = "VersionOneProjectToken";
        public const string JiraProjectNameProperty = "JiraProjectName";

        public JiraProjectMapping() {
            JiraProject = new Mapping();
            VersionOneProject = new Mapping();
        }

        [XmlElement("JIRAProject")]
        public Mapping JiraProject { get; set; }

        public Mapping VersionOneProject { get; set; }

        [XmlIgnore]
        public string VersionOneProjectName {
            get { return VersionOneProject.Name; }
            set { VersionOneProject.Name = value; }
        }

        [XmlIgnore]
        [NonEmptyStringValidator]
        public string VersionOneProjectToken {
            get { return VersionOneProject.Id; }
            set { VersionOneProject.Id = value; }
        }

        [XmlIgnore]
        [NonEmptyStringValidator]
        public string JiraProjectName {
            get { return JiraProject.Name; }
            set { JiraProject.Name = value; }
        }
    }
}