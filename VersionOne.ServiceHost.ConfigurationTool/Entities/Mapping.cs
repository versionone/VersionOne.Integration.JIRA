using System.Xml.Serialization;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    public class Mapping : BaseEntity
    {
        private string id;
        private string name;

        [XmlAttribute("id")]
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        [XmlText]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
    }
}