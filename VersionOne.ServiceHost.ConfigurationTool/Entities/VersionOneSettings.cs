using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using VersionOne.ServiceHost.ConfigurationTool.Validation;
using VersionOne.ServiceHost.ConfigurationTool.Attributes;
using VersionOne.ServiceHost.Core.Configuration;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    /// <summary>
    /// VersionOne connection settings node backing class.
    /// </summary>
    [XmlRoot("Settings")]
    public class VersionOneSettings : INotifyPropertyChanged
    {
        public const string AccessTokenAuthProperty = "AccessTokenAuth";

        public const string ApplicationUrlProperty = "ApplicationUrl";
        public const string AccessTokenProperty = "AccessToken";

        private string applicationUrl;
        private string accessToken;

        public VersionOneSettings()
        {
            ProxySettings = new ProxyConnectionSettings();
        }

        [XmlElement("APIVersion")]
        public string ApiVersion
        {
            get { return "7.2.0.0"; }
            set { }
        }

        public string AuthenticationType { get; set; }

        [HelpString(HelpResourceKey = "V1PageVersionOneUrl")]
        [NonEmptyStringValidator]
        public string ApplicationUrl
        {
            get { return applicationUrl; }
            set
            {
                if (applicationUrl != value)
                {
                    applicationUrl = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NonEmptyStringValidator]
        public string AccessToken
        {
            get { return accessToken; }
            set
            {
                if (accessToken != value)
                {
                    accessToken = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ProxyConnectionSettings ProxySettings { get; set; }

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