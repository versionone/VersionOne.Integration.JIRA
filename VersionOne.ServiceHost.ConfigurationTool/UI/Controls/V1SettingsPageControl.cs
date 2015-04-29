using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VersionOne.ServiceHost.ConfigurationTool.Entities;
using VersionOne.ServiceHost.ConfigurationTool.UI.Interfaces;
using VersionOne.ServiceHost.Core.Configuration;
using VersionOneSettings = VersionOne.ServiceHost.ConfigurationTool.Entities.VersionOneSettings;

namespace VersionOne.ServiceHost.ConfigurationTool.UI.Controls
{
    public partial class V1SettingsPageControl : BasePageControl<ServiceHostConfiguration>, IGeneralPageView
    {
        public event EventHandler<ConnectionValidationEventArgs> ValidationRequested;

        public V1SettingsPageControl()
        {
            InitializeComponent();

            btnVerifyV1Connection.Click += btnVerifyV1Connection_Click;
            rbtnAccessTokenAuth.CheckedChanged += radioButtons_CheckedChanged;
            rbtnBasicAuth.CheckedChanged += radioButtons_CheckedChanged;
            rbtnIntegratedAuth.CheckedChanged += radioButtons_CheckedChanged;
            rbtnIntegratedWithCredentialsAuth.CheckedChanged += radioButtons_CheckedChanged;
            chkUseProxy.CheckedChanged += chkUseProxy_CheckedChanged;

            AddValidationProvider(typeof(VersionOneSettings));
            AddValidationProvider(typeof(ProxyConnectionSettings));

            AddControlTextValidation<VersionOneSettings>(txtServerUrl, VersionOneSettings.ApplicationUrlProperty);
            AddControlTextValidation<VersionOneSettings>(txtAccessToken, VersionOneSettings.AccessTokenProperty);
            AddControlTextValidation<VersionOneSettings>(txtUsername, VersionOneSettings.UsernameProperty);
            AddControlTextValidation<VersionOneSettings>(txtPassword, VersionOneSettings.PasswordProperty);

            CheckProxyForm();
        }

        public override void DataBind()
        {
            AddControlBinding(txtServerUrl, Model.Settings, VersionOneSettings.ApplicationUrlProperty);
            AddControlBinding(txtAccessToken, Model.Settings, VersionOneSettings.AccessTokenProperty);
            AddControlBinding(txtUsername, Model.Settings, VersionOneSettings.UsernameProperty);
            AddControlBinding(txtPassword, Model.Settings, VersionOneSettings.PasswordProperty);
            AddControlBinding(chkUseProxy, Model.ProxySettings, ProxyConnectionSettings.EnabledProperty);
            AddControlBinding(txtProxyUri, Model.ProxySettings, ProxyConnectionSettings.UriProperty);
            AddControlBinding(txtProxyUsername, Model.ProxySettings, ProxyConnectionSettings.UsernameProperty);
            AddControlBinding(txtProxyPassword, Model.ProxySettings, ProxyConnectionSettings.PasswordProperty);
            AddControlBinding(txtProxyDomain, Model.ProxySettings, ProxyConnectionSettings.DomainProperty);

            BindHelpStrings();

            switch (Model.Settings.AuthenticationType)
            {
                case AuthenticationTypes.AccessToken:
                    rbtnAccessTokenAuth.Checked = true;
                    break;
                case AuthenticationTypes.Basic:
                    rbtnBasicAuth.Checked = true;
                    break;
                case AuthenticationTypes.Integrated:
                    rbtnIntegratedAuth.Checked = true;
                    break;
                case AuthenticationTypes.IntegratedWithCredentials:
                    rbtnIntegratedWithCredentialsAuth.Checked = true;
                    break;
                default:
                    throw new Exception("You must set an authentication type in config file"); // TODO: check error message
            }
        }

        private void BindHelpStrings()
        {
            AddHelpSupport(txtServerUrl, Model.Settings, VersionOneSettings.ApplicationUrlProperty);
            AddHelpSupport(chkUseProxy, Model.Settings.ProxySettings, ProxyConnectionSettings.EnabledProperty);
        }

        #region IGeneralPageView members
        public void SetValidationResult(bool validationSuccessful)
        {
            lblV1ConnectionValidationResult.Visible = true;

            if (validationSuccessful)
            {
                lblV1ConnectionValidationResult.ForeColor = Color.Green;
                lblV1ConnectionValidationResult.Text = Resources.V1SettingsValidMessage;
            }
            else
            {
                lblV1ConnectionValidationResult.ForeColor = Color.Red;
                lblV1ConnectionValidationResult.Text = Resources.V1SettingsInvalidMessage;
            }
        }

        public void SetProxyUrlValidationFault(bool validationSuccessful)
        {
            lblV1ConnectionValidationResult.Visible = !validationSuccessful;

            if (!validationSuccessful)
            {
                lblV1ConnectionValidationResult.ForeColor = Color.Red;
                lblV1ConnectionValidationResult.Text = Resources.V1ProxyUrlSettingsIsNotCorrect;
            }
        }
        #endregion

        #region Event handlers

        private void btnVerifyV1Connection_Click(object sender, EventArgs e)
        {
            if (ValidationRequested == null)
                return;

            var settings = new VersionOneSettings
            {
                ApplicationUrl = txtServerUrl.Text,
                AccessToken = txtAccessToken.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                ProxySettings = new ProxyConnectionSettings
                {
                    Enabled = chkUseProxy.Checked,
                    Domain = txtProxyDomain.Text,
                    UserName = txtProxyUsername.Text,
                    Password = txtProxyPassword.Text,
                    Uri = txtProxyUri.Text
                }
            };

            if (rbtnAccessTokenAuth.Checked)
                settings.AuthenticationType = AuthenticationTypes.AccessToken;
            else if (rbtnBasicAuth.Checked)
                settings.AuthenticationType = AuthenticationTypes.Basic;
            else if (rbtnIntegratedAuth.Checked)
                settings.AuthenticationType = AuthenticationTypes.Integrated;
            else if (rbtnIntegratedWithCredentialsAuth.Checked)
                settings.AuthenticationType = AuthenticationTypes.IntegratedWithCredentials;

            lblV1ConnectionValidationResult.Text = string.Empty;

            ValidationRequested(this, new ConnectionValidationEventArgs(settings));
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAccessTokenAuth.Checked)
            {
                AddControlTextValidation<VersionOneSettings>(txtAccessToken, VersionOneSettings.AccessTokenProperty);
                RemoveControlValidation<VersionOneSettings>(txtUsername);
                RemoveControlValidation<VersionOneSettings>(txtPassword);
                Model.Settings.AuthenticationType = AuthenticationTypes.AccessToken;
            }
            else if (rbtnBasicAuth.Checked)
            {
                AddControlTextValidation<VersionOneSettings>(txtUsername, VersionOneSettings.UsernameProperty);
                AddControlTextValidation<VersionOneSettings>(txtPassword, VersionOneSettings.PasswordProperty);
                RemoveControlValidation<VersionOneSettings>(txtAccessToken);
                Model.Settings.AuthenticationType = AuthenticationTypes.Basic;
            }
            else if (rbtnIntegratedAuth.Checked)
            {
                RemoveControlValidation<VersionOneSettings>(txtAccessToken);
                RemoveControlValidation<VersionOneSettings>(txtUsername);
                RemoveControlValidation<VersionOneSettings>(txtPassword);
                Model.Settings.AuthenticationType = AuthenticationTypes.Integrated;
            }
            else if (rbtnIntegratedWithCredentialsAuth.Checked)
            {
                AddControlTextValidation<VersionOneSettings>(txtUsername, VersionOneSettings.UsernameProperty);
                AddControlTextValidation<VersionOneSettings>(txtPassword, VersionOneSettings.PasswordProperty);
                RemoveControlValidation<VersionOneSettings>(txtAccessToken);
                Model.Settings.AuthenticationType = AuthenticationTypes.IntegratedWithCredentials;
            }

            ErrorProvider.Clear();
            UpdateTextBoxesState();
        }

        private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            CheckProxyForm();
        }

        private void UpdateTextBoxesState()
        {
            txtAccessToken.Enabled = rbtnAccessTokenAuth.Checked;
            txtUsername.Enabled = rbtnBasicAuth.Checked || rbtnIntegratedWithCredentialsAuth.Checked;
            txtPassword.Enabled = rbtnBasicAuth.Checked || rbtnIntegratedWithCredentialsAuth.Checked;
        }

        #endregion

        private void CheckProxyForm()
        {
            if (chkUseProxy.Checked)
            {
                AddControlTextValidation<ProxyConnectionSettings>(txtProxyUri, ProxyConnectionSettings.UriProperty);
                txtProxyUri.Enabled = true;
                txtProxyUsername.Enabled = true;
                txtProxyPassword.Enabled = true;
                txtProxyDomain.Enabled = true;
            }
            else
            {
                RemoveControlValidation<ProxyConnectionSettings>(txtProxyUri);
                txtProxyUri.Enabled = false;
                txtProxyUsername.Enabled = false;
                txtProxyPassword.Enabled = false;
                txtProxyDomain.Enabled = false;
            }
        }
    }
}