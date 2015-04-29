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
    public class VersionOneSettings
    {
        public const string AccessTokenAuthProperty = "AccessTokenAuth";
        public const string BasicAuthProperty = "BasicAuth";
        public const string IntegratedAuthProperty = "IntegratedAuth";

        public const string ApplicationUrlProperty = "ApplicationUrl";
        public const string AccessTokenProperty = "AccessToken";
        public const string UsernameProperty = "Username";
        public const string PasswordProperty = "Password";

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

        public AuthenticationTypes AuthenticationType { get; set; }

        [HelpString(HelpResourceKey = "V1PageVersionOneUrl")]
        [NonEmptyStringValidator]
        public string ApplicationUrl { get; set; }

        [NonEmptyStringValidator]
        public string AccessToken { get; set; }

        [NonEmptyStringValidator]
        public string Username { get; set; }

        [NonEmptyStringValidator]
        public string Password { get; set; }

        public ProxyConnectionSettings ProxySettings { get; set; }
    }
}