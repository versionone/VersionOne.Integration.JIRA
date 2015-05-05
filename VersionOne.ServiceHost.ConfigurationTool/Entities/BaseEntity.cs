using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using VersionOne.ServiceHost.ConfigurationTool.Attributes;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    public abstract class BaseEntity : INotifyPropertyChanged
    {
        public const string DisabledProperty = "Disabled";

        protected bool disabled;

        [XmlIgnore]
        public virtual string TagName { get; set; }

        [XmlIgnore]
        [HelpString(HelpResourceKey = "CommonDisabled")]
        public virtual bool Disabled
        {
            get { return disabled; }
            set
            {
                disabled = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}