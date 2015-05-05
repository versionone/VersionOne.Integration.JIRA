using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using VersionOne.ServiceHost.ConfigurationTool.Validation;
using VersionOne.ServiceHost.ConfigurationTool.Attributes;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    [XmlRoot("ProxySettings")]
    public class ProxyConnectionSettings : INotifyPropertyChanged
    {
        public readonly static string EnabledProperty = "Enabled";
        public readonly static string UriProperty = "Uri";
        public readonly static string UsernameProperty = "UserName";
        public readonly static string PasswordProperty = "Password";
        public readonly static string DomainProperty = "Domain";

        private bool enabled;
        private string uri;
        private string userName;
        private string password;
        private string domain;

        [HelpString(HelpResourceKey = "V1PageProxyEnabled")]
        [XmlIgnore]
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                NotifyPropertyChanged();
            }
        }

        [XmlAttribute("disabled")]
        public int DisabledNumeric
        {
            get { return Convert.ToInt32(!Enabled); }
            set { Enabled = !Convert.ToBoolean(value); }
        }

        [NonEmptyStringValidator]
        public string Uri
        {
            get { return uri; }
            set
            {
                uri = value;
                NotifyPropertyChanged();
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }

        public string Domain
        {
            get { return domain; }
            set
            {
                domain = value;
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