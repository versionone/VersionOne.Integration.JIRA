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
			this.lblAccessTokenMessage = new System.Windows.Forms.Label();

		
			this.SuspendLayout();


			//Access Token Info Message
			this.lblAccessTokenMessage.AutoSize = true;
			this.lblAccessTokenMessage.Location = new System.Drawing.Point(17, 15);
			this.lblAccessTokenMessage.Name = "lblServerUrl";
			this.lblAccessTokenMessage.Size = new System.Drawing.Size(200, 13);
			this.lblAccessTokenMessage.TabIndex = 1;
			this.lblAccessTokenMessage.Text = "Connection to VersionOne only uses Access Token";

			// 
			// txtServerUrl
			// 
			this.txtServerUrl.Location = new System.Drawing.Point(106, 40);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(375, 20);
            this.txtServerUrl.TabIndex = 2;
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.AutoSize = true;
            this.lblServerUrl.Location = new System.Drawing.Point(17, 43);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(63, 13);
            this.lblServerUrl.TabIndex = 1;
            this.lblServerUrl.Text = "Server URL";

			// 
			// lblAccessToken
			// 
			this.lblAccessToken.AutoSize = true;
			this.lblAccessToken.Location = new System.Drawing.Point(17, 70);
			this.lblAccessToken.Name = "lblAccessToken";
			this.lblAccessToken.Size = new System.Drawing.Size(76, 13);
			this.lblAccessToken.TabIndex = 3;
			this.lblAccessToken.Text = "Access Token";
			// 
			// txtAccessToken
			// 
			this.txtAccessToken.Location = new System.Drawing.Point(106, 65);
			this.txtAccessToken.Name = "txtAccessToken";
			this.txtAccessToken.Size = new System.Drawing.Size(375, 20);
			this.txtAccessToken.TabIndex = 4;

			// 
			// chkUseProxy
			// 
			this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseProxy.Location = new System.Drawing.Point(332, 110);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(149, 17);
            this.chkUseProxy.TabIndex = 9;
            this.chkUseProxy.Text = "Use Proxy For Connection";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            // 
            // lblProxyUri
            // 
            this.lblProxyUri.AutoSize = true;
            this.lblProxyUri.Location = new System.Drawing.Point(17, 130);
            this.lblProxyUri.Name = "lblProxyUri";
            this.lblProxyUri.Size = new System.Drawing.Size(58, 13);
            this.lblProxyUri.TabIndex = 10;
            this.lblProxyUri.Text = "Proxy URL";
			// 
			// txtProxyUri
			// 
			this.txtProxyUri.Location = new System.Drawing.Point(106, 130);
			this.txtProxyUri.Name = "txtProxyUri";
			this.txtProxyUri.Size = new System.Drawing.Size(375, 20);
			this.txtProxyUri.TabIndex = 11;

			// 
			// lblProxyUserName
			// 
			this.lblProxyUserName.AutoSize = true;
            this.lblProxyUserName.Location = new System.Drawing.Point(17, 155);
            this.lblProxyUserName.Name = "lblProxyUserName";
            this.lblProxyUserName.Size = new System.Drawing.Size(84, 13);
            this.lblProxyUserName.TabIndex = 12;
            this.lblProxyUserName.Text = "Proxy Username";

			// 
			// txtProxyUsername
			// 
			this.txtProxyUsername.Location = new System.Drawing.Point(106, 155);
			this.txtProxyUsername.Name = "txtProxyUsername";
			this.txtProxyUsername.Size = new System.Drawing.Size(375, 20);
			this.txtProxyUsername.TabIndex = 13;
			

			// 
			// lblProxyPassword
			// 
			this.lblProxyPassword.AutoSize = true;
			this.lblProxyPassword.Location = new System.Drawing.Point(17, 185);
			this.lblProxyPassword.Name = "lblProxyPassword";
			this.lblProxyPassword.Size = new System.Drawing.Size(82, 13);
			this.lblProxyPassword.TabIndex = 14;
			this.lblProxyPassword.Text = "Proxy Password";

			// 
			// txtProxyPassword
			// 
			this.txtProxyPassword.Location = new System.Drawing.Point(106, 182);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.Size = new System.Drawing.Size(375, 20);
            this.txtProxyPassword.TabIndex = 15;
            // 
            // lblProxyDomain
            // 
            this.lblProxyDomain.AutoSize = true;
            this.lblProxyDomain.Location = new System.Drawing.Point(17, 210);
            this.lblProxyDomain.Name = "lblProxyDomain";
            this.lblProxyDomain.Size = new System.Drawing.Size(72, 13);
            this.lblProxyDomain.TabIndex = 16;
            this.lblProxyDomain.Text = "Proxy Domain";
            // 
            // txtProxyDomain
            // 
            this.txtProxyDomain.Location = new System.Drawing.Point(106, 207);
            this.txtProxyDomain.Name = "txtProxyDomain";
            this.txtProxyDomain.Size = new System.Drawing.Size(375, 20);
            this.txtProxyDomain.TabIndex = 17;

			// 
			// btnVerifyV1Connection
			// 
			this.btnVerifyV1Connection.Location = new System.Drawing.Point(394, 240);
			this.btnVerifyV1Connection.Name = "btnVerifyV1Connection";
			this.btnVerifyV1Connection.Size = new System.Drawing.Size(87, 27);
			this.btnVerifyV1Connection.TabIndex = 18;
			this.btnVerifyV1Connection.Text = "Validate";
			this.btnVerifyV1Connection.UseVisualStyleBackColor = true;

			// 
			// lblV1ConnectionValidationResult
			// 
			this.lblV1ConnectionValidationResult.AutoSize = true;
			this.lblV1ConnectionValidationResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblV1ConnectionValidationResult.Location = new System.Drawing.Point(17, 270);
			this.lblV1ConnectionValidationResult.Name = "lblV1ConnectionValidationResult";
			this.lblV1ConnectionValidationResult.Size = new System.Drawing.Size(153, 13);
			this.lblV1ConnectionValidationResult.TabIndex = 19;
			this.lblV1ConnectionValidationResult.Text = "V1 Connection validation result";
			this.lblV1ConnectionValidationResult.Visible = false;

			// 
			// V1SettingsPageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
			this.Controls.Add(this.lblAccessTokenMessage);
			this.Controls.Add(this.txtServerUrl);
            this.Controls.Add(this.lblServerUrl);
            this.Name = "V1SettingsPageControl";
            this.Size = new System.Drawing.Size(540, 440);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblV1ConnectionValidationResult;
        private System.Windows.Forms.Button btnVerifyV1Connection;
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
	    private System.Windows.Forms.Label lblAccessTokenMessage;
    }
}
