namespace VersionOne.ServiceHost.ConfigurationTool.UI.Controls {
    partial class V1SettingsPageControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblV1ConnectionValidationResult = new System.Windows.Forms.Label();
            this.btnVerifyV1Connection = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.lblServerUrl = new System.Windows.Forms.Label();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.lblProxyUri = new System.Windows.Forms.Label();
            this.lblProxyUserName = new System.Windows.Forms.Label();
            this.lblProxyPassword = new System.Windows.Forms.Label();
            this.txtProxyUri = new System.Windows.Forms.TextBox();
            this.txtProxyUsername = new System.Windows.Forms.TextBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.lblProxyDomain = new System.Windows.Forms.Label();
            this.txtProxyDomain = new System.Windows.Forms.TextBox();
            this.lblAccessToken = new System.Windows.Forms.Label();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.gbAuthentication = new System.Windows.Forms.GroupBox();
            this.rbtnIntegratedWithCredentialsAuth = new System.Windows.Forms.RadioButton();
            this.rbtnAccessTokenAuth = new System.Windows.Forms.RadioButton();
            this.rbtnIntegratedAuth = new System.Windows.Forms.RadioButton();
            this.rbtnBasicAuth = new System.Windows.Forms.RadioButton();
            this.gbAuthentication.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblV1ConnectionValidationResult
            // 
            this.lblV1ConnectionValidationResult.AutoSize = true;
            this.lblV1ConnectionValidationResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblV1ConnectionValidationResult.Location = new System.Drawing.Point(17, 371);
            this.lblV1ConnectionValidationResult.Name = "lblV1ConnectionValidationResult";
            this.lblV1ConnectionValidationResult.Size = new System.Drawing.Size(153, 13);
            this.lblV1ConnectionValidationResult.TabIndex = 16;
            this.lblV1ConnectionValidationResult.Text = "V1 Connection validation result";
            this.lblV1ConnectionValidationResult.Visible = false;
            // 
            // btnVerifyV1Connection
            // 
            this.btnVerifyV1Connection.Location = new System.Drawing.Point(394, 364);
            this.btnVerifyV1Connection.Name = "btnVerifyV1Connection";
            this.btnVerifyV1Connection.Size = new System.Drawing.Size(87, 27);
            this.btnVerifyV1Connection.TabIndex = 17;
            this.btnVerifyV1Connection.Text = "Validate";
            this.btnVerifyV1Connection.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(106, 155);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(375, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(17, 158);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(106, 120);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(375, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(17, 123);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Location = new System.Drawing.Point(106, 50);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(375, 20);
            this.txtServerUrl.TabIndex = 2;
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.AutoSize = true;
            this.lblServerUrl.Location = new System.Drawing.Point(17, 53);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(63, 13);
            this.lblServerUrl.TabIndex = 1;
            this.lblServerUrl.Text = "Server URL";
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseProxy.Location = new System.Drawing.Point(332, 197);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(149, 17);
            this.chkUseProxy.TabIndex = 7;
            this.chkUseProxy.Text = "Use Proxy For Connection";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            // 
            // lblProxyUri
            // 
            this.lblProxyUri.AutoSize = true;
            this.lblProxyUri.Location = new System.Drawing.Point(17, 223);
            this.lblProxyUri.Name = "lblProxyUri";
            this.lblProxyUri.Size = new System.Drawing.Size(58, 13);
            this.lblProxyUri.TabIndex = 8;
            this.lblProxyUri.Text = "Proxy URL";
            // 
            // lblProxyUserName
            // 
            this.lblProxyUserName.AutoSize = true;
            this.lblProxyUserName.Location = new System.Drawing.Point(17, 259);
            this.lblProxyUserName.Name = "lblProxyUserName";
            this.lblProxyUserName.Size = new System.Drawing.Size(84, 13);
            this.lblProxyUserName.TabIndex = 10;
            this.lblProxyUserName.Text = "Proxy Username";
            // 
            // lblProxyPassword
            // 
            this.lblProxyPassword.AutoSize = true;
            this.lblProxyPassword.Location = new System.Drawing.Point(17, 295);
            this.lblProxyPassword.Name = "lblProxyPassword";
            this.lblProxyPassword.Size = new System.Drawing.Size(82, 13);
            this.lblProxyPassword.TabIndex = 12;
            this.lblProxyPassword.Text = "Proxy Password";
            // 
            // txtProxyUri
            // 
            this.txtProxyUri.Location = new System.Drawing.Point(106, 220);
            this.txtProxyUri.Name = "txtProxyUri";
            this.txtProxyUri.Size = new System.Drawing.Size(375, 20);
            this.txtProxyUri.TabIndex = 9;
            // 
            // txtProxyUsername
            // 
            this.txtProxyUsername.Location = new System.Drawing.Point(106, 256);
            this.txtProxyUsername.Name = "txtProxyUsername";
            this.txtProxyUsername.Size = new System.Drawing.Size(375, 20);
            this.txtProxyUsername.TabIndex = 11;
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(106, 292);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.Size = new System.Drawing.Size(375, 20);
            this.txtProxyPassword.TabIndex = 13;
            // 
            // lblProxyDomain
            // 
            this.lblProxyDomain.AutoSize = true;
            this.lblProxyDomain.Location = new System.Drawing.Point(17, 331);
            this.lblProxyDomain.Name = "lblProxyDomain";
            this.lblProxyDomain.Size = new System.Drawing.Size(72, 13);
            this.lblProxyDomain.TabIndex = 14;
            this.lblProxyDomain.Text = "Proxy Domain";
            // 
            // txtProxyDomain
            // 
            this.txtProxyDomain.Location = new System.Drawing.Point(106, 328);
            this.txtProxyDomain.Name = "txtProxyDomain";
            this.txtProxyDomain.Size = new System.Drawing.Size(375, 20);
            this.txtProxyDomain.TabIndex = 15;
            // 
            // lblAccessToken
            // 
            this.lblAccessToken.AutoSize = true;
            this.lblAccessToken.Location = new System.Drawing.Point(17, 88);
            this.lblAccessToken.Name = "lblAccessToken";
            this.lblAccessToken.Size = new System.Drawing.Size(76, 13);
            this.lblAccessToken.TabIndex = 18;
            this.lblAccessToken.Text = "Access Token";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(106, 85);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(375, 20);
            this.txtAccessToken.TabIndex = 19;
            // 
            // gbAuthentication
            // 
            this.gbAuthentication.Controls.Add(this.rbtnIntegratedWithCredentialsAuth);
            this.gbAuthentication.Controls.Add(this.rbtnAccessTokenAuth);
            this.gbAuthentication.Controls.Add(this.rbtnIntegratedAuth);
            this.gbAuthentication.Controls.Add(this.rbtnBasicAuth);
            this.gbAuthentication.Location = new System.Drawing.Point(20, 8);
            this.gbAuthentication.Name = "gbAuthentication";
            this.gbAuthentication.Size = new System.Drawing.Size(461, 36);
            this.gbAuthentication.TabIndex = 23;
            this.gbAuthentication.TabStop = false;
            this.gbAuthentication.Text = "Authentication";
            // 
            // rbtnIntegratedWithCredentialsAuth
            // 
            this.rbtnIntegratedWithCredentialsAuth.AutoSize = true;
            this.rbtnIntegratedWithCredentialsAuth.Location = new System.Drawing.Point(329, 13);
            this.rbtnIntegratedWithCredentialsAuth.Name = "rbtnIntegratedWithCredentialsAuth";
            this.rbtnIntegratedWithCredentialsAuth.Size = new System.Drawing.Size(132, 17);
            this.rbtnIntegratedWithCredentialsAuth.TabIndex = 23;
            this.rbtnIntegratedWithCredentialsAuth.TabStop = true;
            this.rbtnIntegratedWithCredentialsAuth.Text = "NTLM with Credentials";
            this.rbtnIntegratedWithCredentialsAuth.UseVisualStyleBackColor = true;
            // 
            // rbtnAccessTokenAuth
            // 
            this.rbtnAccessTokenAuth.AutoSize = true;
            this.rbtnAccessTokenAuth.Location = new System.Drawing.Point(86, 13);
            this.rbtnAccessTokenAuth.Name = "rbtnAccessTokenAuth";
            this.rbtnAccessTokenAuth.Size = new System.Drawing.Size(94, 17);
            this.rbtnAccessTokenAuth.TabIndex = 20;
            this.rbtnAccessTokenAuth.TabStop = true;
            this.rbtnAccessTokenAuth.Text = "Access Token";
            this.rbtnAccessTokenAuth.UseVisualStyleBackColor = true;
            // 
            // rbtnIntegratedAuth
            // 
            this.rbtnIntegratedAuth.AutoSize = true;
            this.rbtnIntegratedAuth.Location = new System.Drawing.Point(259, 13);
            this.rbtnIntegratedAuth.Name = "rbtnIntegratedAuth";
            this.rbtnIntegratedAuth.Size = new System.Drawing.Size(55, 17);
            this.rbtnIntegratedAuth.TabIndex = 22;
            this.rbtnIntegratedAuth.TabStop = true;
            this.rbtnIntegratedAuth.Text = "NTLM";
            this.rbtnIntegratedAuth.UseVisualStyleBackColor = true;
            // 
            // rbtnBasicAuth
            // 
            this.rbtnBasicAuth.AutoSize = true;
            this.rbtnBasicAuth.Location = new System.Drawing.Point(194, 13);
            this.rbtnBasicAuth.Name = "rbtnBasicAuth";
            this.rbtnBasicAuth.Size = new System.Drawing.Size(51, 17);
            this.rbtnBasicAuth.TabIndex = 21;
            this.rbtnBasicAuth.TabStop = true;
            this.rbtnBasicAuth.Text = "Basic";
            this.rbtnBasicAuth.UseVisualStyleBackColor = true;
            // 
            // V1SettingsPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAuthentication);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.lblAccessToken);
            this.Controls.Add(this.txtProxyDomain);
            this.Controls.Add(this.lblProxyDomain);
            this.Controls.Add(this.txtProxyPassword);
            this.Controls.Add(this.txtProxyUsername);
            this.Controls.Add(this.txtProxyUri);
            this.Controls.Add(this.lblProxyPassword);
            this.Controls.Add(this.lblProxyUserName);
            this.Controls.Add(this.lblProxyUri);
            this.Controls.Add(this.chkUseProxy);
            this.Controls.Add(this.lblV1ConnectionValidationResult);
            this.Controls.Add(this.btnVerifyV1Connection);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtServerUrl);
            this.Controls.Add(this.lblServerUrl);
            this.Name = "V1SettingsPageControl";
            this.Size = new System.Drawing.Size(540, 400);
            this.gbAuthentication.ResumeLayout(false);
            this.gbAuthentication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblV1ConnectionValidationResult;
        private System.Windows.Forms.Button btnVerifyV1Connection;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.Label lblServerUrl;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.Label lblProxyUri;
        private System.Windows.Forms.Label lblProxyUserName;
        private System.Windows.Forms.Label lblProxyPassword;
        private System.Windows.Forms.TextBox txtProxyUri;
        private System.Windows.Forms.TextBox txtProxyUsername;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label lblProxyDomain;
        private System.Windows.Forms.TextBox txtProxyDomain;
        private System.Windows.Forms.Label lblAccessToken;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.GroupBox gbAuthentication;
        private System.Windows.Forms.RadioButton rbtnAccessTokenAuth;
        private System.Windows.Forms.RadioButton rbtnIntegratedAuth;
        private System.Windows.Forms.RadioButton rbtnBasicAuth;
        private System.Windows.Forms.RadioButton rbtnIntegratedWithCredentialsAuth;
    }
}
