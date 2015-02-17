using System.Windows.Forms;
using VersionOne.ServiceHost.ConfigurationTool.Entities;

namespace VersionOne.ServiceHost.ConfigurationTool.UI.Controls {
    partial class JiraPageControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            this.chkDisabled = new System.Windows.Forms.CheckBox();
            this.grpVersionOneDefectAttributes = new System.Windows.Forms.GroupBox();
            this.cboSourceFieldValue = new System.Windows.Forms.ComboBox();
            this.txtJiraUrlTitle = new System.Windows.Forms.TextBox();
            this.lblJiraUrlTitle = new System.Windows.Forms.Label();
            this.txtJiraUrlTempl = new System.Windows.Forms.TextBox();
            this.lblJiraUrlTempl = new System.Windows.Forms.Label();
            this.lblSourceFieldValue = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblTimerInterval = new System.Windows.Forms.Label();
            this.nmdInterval = new System.Windows.Forms.NumericUpDown();
            this.txtCreateDefectFilterId = new System.Windows.Forms.TextBox();
            this.lblCreateDefectFilterId = new System.Windows.Forms.Label();
            this.txtDefectLinkFieldId = new System.Windows.Forms.TextBox();
            this.lblDefectLinkFieldId = new System.Windows.Forms.Label();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.lblConnectionValidation = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.lblAssigneeStateChanged = new System.Windows.Forms.Label();
            this.txtAssigneeStateChanged = new System.Windows.Forms.TextBox();
            this.lblProgressWorkflow = new System.Windows.Forms.Label();
            this.txtProgressWorkflow = new System.Windows.Forms.TextBox();
            this.lblProgressWorkflowClosed = new System.Windows.Forms.Label();
            this.txtProgressWorkflowClosed = new System.Windows.Forms.TextBox();
            this.lblCommentCloseFieldId = new System.Windows.Forms.Label();
            this.lblCommentCreateFieldId = new System.Windows.Forms.Label();
            this.lblCreateFieldId = new System.Windows.Forms.Label();
            this.txtCreateFieldId = new System.Windows.Forms.TextBox();
            this.lblCreateFieldValue = new System.Windows.Forms.Label();
            this.txtCreateFieldValue = new System.Windows.Forms.TextBox();
            this.lblCloseFieldId = new System.Windows.Forms.Label();
            this.txtCloseFieldId = new System.Windows.Forms.TextBox();
            this.lblCloseFieldValue = new System.Windows.Forms.Label();
            this.txtCloseFieldValue = new System.Windows.Forms.TextBox();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.chkDefectFilterDisabled = new System.Windows.Forms.CheckBox();
            this.lblCreateStoryFilterId = new System.Windows.Forms.Label();
            this.txtCreateStoryFilterId = new System.Windows.Forms.TextBox();
            this.chkStoryFilterDisabled = new System.Windows.Forms.CheckBox();
            this.grpProjectMappings = new System.Windows.Forms.GroupBox();
            this.btnDeleteProjectMapping = new System.Windows.Forms.Button();
            this.grdProjectMappings = new System.Windows.Forms.DataGridView();
            this.colVersionOneProject = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colJiraProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsProjectMappings = new System.Windows.Forms.BindingSource(this.components);
            this.bsPriorityMappings = new System.Windows.Forms.BindingSource(this.components);
            this.tcJiraData = new System.Windows.Forms.TabControl();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tpMappings = new System.Windows.Forms.TabPage();
            this.grpPriorityMappings = new System.Windows.Forms.GroupBox();
            this.lblPriorityValidationNote = new System.Windows.Forms.Label();
            this.btnDeletePriorityMapping = new System.Windows.Forms.Button();
            this.grdPriorityMappings = new System.Windows.Forms.DataGridView();
            this.colVersionOnePriority = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colJiraPriority = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grpVersionOneDefectAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmdInterval)).BeginInit();
            this.grpConnection.SuspendLayout();
            this.grpUpdate.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpProjectMappings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProjectMappings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjectMappings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPriorityMappings)).BeginInit();
            this.tcJiraData.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tpMappings.SuspendLayout();
            this.grpPriorityMappings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPriorityMappings)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDisabled
            // 
            this.chkDisabled.AutoSize = true;
            this.chkDisabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDisabled.Location = new System.Drawing.Point(405, 11);
            this.chkDisabled.Name = "chkDisabled";
            this.chkDisabled.Size = new System.Drawing.Size(67, 17);
            this.chkDisabled.TabIndex = 0;
            this.chkDisabled.Text = "Disabled";
            this.chkDisabled.UseVisualStyleBackColor = true;
            // 
            // grpVersionOneDefectAttributes
            // 
            this.grpVersionOneDefectAttributes.Controls.Add(this.cboSourceFieldValue);
            this.grpVersionOneDefectAttributes.Controls.Add(this.txtJiraUrlTitle);
            this.grpVersionOneDefectAttributes.Controls.Add(this.lblJiraUrlTitle);
            this.grpVersionOneDefectAttributes.Controls.Add(this.txtJiraUrlTempl);
            this.grpVersionOneDefectAttributes.Controls.Add(this.lblJiraUrlTempl);
            this.grpVersionOneDefectAttributes.Controls.Add(this.lblSourceFieldValue);
            this.grpVersionOneDefectAttributes.Location = new System.Drawing.Point(12, 134);
            this.grpVersionOneDefectAttributes.Name = "grpVersionOneDefectAttributes";
            this.grpVersionOneDefectAttributes.Size = new System.Drawing.Size(502, 108);
            this.grpVersionOneDefectAttributes.TabIndex = 1;
            this.grpVersionOneDefectAttributes.TabStop = false;
            this.grpVersionOneDefectAttributes.Text = "VersionOne Workitem attributes";
            // 
            // cboSourceFieldValue
            // 
            this.cboSourceFieldValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSourceFieldValue.FormattingEnabled = true;
            this.cboSourceFieldValue.Location = new System.Drawing.Point(129, 19);
            this.cboSourceFieldValue.Name = "cboSourceFieldValue";
            this.cboSourceFieldValue.Size = new System.Drawing.Size(327, 21);
            this.cboSourceFieldValue.TabIndex = 1;
            // 
            // txtJiraUrlTitle
            // 
            this.txtJiraUrlTitle.Location = new System.Drawing.Point(129, 76);
            this.txtJiraUrlTitle.Name = "txtJiraUrlTitle";
            this.txtJiraUrlTitle.Size = new System.Drawing.Size(327, 20);
            this.txtJiraUrlTitle.TabIndex = 5;
            // 
            // lblJiraUrlTitle
            // 
            this.lblJiraUrlTitle.AutoSize = true;
            this.lblJiraUrlTitle.Location = new System.Drawing.Point(12, 79);
            this.lblJiraUrlTitle.Name = "lblJiraUrlTitle";
            this.lblJiraUrlTitle.Size = new System.Drawing.Size(52, 13);
            this.lblJiraUrlTitle.TabIndex = 4;
            this.lblJiraUrlTitle.Text = "URL Title";
            // 
            // txtJiraUrlTempl
            // 
            this.txtJiraUrlTempl.Location = new System.Drawing.Point(129, 48);
            this.txtJiraUrlTempl.Name = "txtJiraUrlTempl";
            this.txtJiraUrlTempl.Size = new System.Drawing.Size(327, 20);
            this.txtJiraUrlTempl.TabIndex = 3;
            // 
            // lblJiraUrlTempl
            // 
            this.lblJiraUrlTempl.AutoSize = true;
            this.lblJiraUrlTempl.Location = new System.Drawing.Point(12, 51);
            this.lblJiraUrlTempl.Name = "lblJiraUrlTempl";
            this.lblJiraUrlTempl.Size = new System.Drawing.Size(76, 13);
            this.lblJiraUrlTempl.TabIndex = 2;
            this.lblJiraUrlTempl.Text = "URL Template";
            // 
            // lblSourceFieldValue
            // 
            this.lblSourceFieldValue.AutoSize = true;
            this.lblSourceFieldValue.Location = new System.Drawing.Point(12, 22);
            this.lblSourceFieldValue.Name = "lblSourceFieldValue";
            this.lblSourceFieldValue.Size = new System.Drawing.Size(41, 13);
            this.lblSourceFieldValue.TabIndex = 0;
            this.lblSourceFieldValue.Text = "Source";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(199, 255);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(43, 13);
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Text = "minutes";
            // 
            // lblTimerInterval
            // 
            this.lblTimerInterval.AutoSize = true;
            this.lblTimerInterval.Location = new System.Drawing.Point(24, 255);
            this.lblTimerInterval.Name = "lblTimerInterval";
            this.lblTimerInterval.Size = new System.Drawing.Size(62, 13);
            this.lblTimerInterval.TabIndex = 2;
            this.lblTimerInterval.Text = "Poll Interval";
            // 
            // nmdInterval
            // 
            this.nmdInterval.Location = new System.Drawing.Point(141, 251);
            this.nmdInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmdInterval.Name = "nmdInterval";
            this.nmdInterval.Size = new System.Drawing.Size(52, 20);
            this.nmdInterval.TabIndex = 3;
            this.nmdInterval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtCreateDefectFilterId
            // 
            this.txtCreateDefectFilterId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreateDefectFilterId.Location = new System.Drawing.Point(130, 19);
            this.txtCreateDefectFilterId.Name = "txtCreateDefectFilterId";
            this.txtCreateDefectFilterId.Size = new System.Drawing.Size(115, 20);
            this.txtCreateDefectFilterId.TabIndex = 1;
            // 
            // lblCreateDefectFilterId
            // 
            this.lblCreateDefectFilterId.AutoSize = true;
            this.lblCreateDefectFilterId.Location = new System.Drawing.Point(12, 23);
            this.lblCreateDefectFilterId.Name = "lblCreateDefectFilterId";
            this.lblCreateDefectFilterId.Size = new System.Drawing.Size(112, 13);
            this.lblCreateDefectFilterId.TabIndex = 0;
            this.lblCreateDefectFilterId.Text = "Create Defect Filter ID";
            // 
            // txtDefectLinkFieldId
            // 
            this.txtDefectLinkFieldId.Location = new System.Drawing.Point(154, 18);
            this.txtDefectLinkFieldId.Name = "txtDefectLinkFieldId";
            this.txtDefectLinkFieldId.Size = new System.Drawing.Size(302, 20);
            this.txtDefectLinkFieldId.TabIndex = 1;
            // 
            // lblDefectLinkFieldId
            // 
            this.lblDefectLinkFieldId.AutoSize = true;
            this.lblDefectLinkFieldId.Location = new System.Drawing.Point(12, 22);
            this.lblDefectLinkFieldId.Name = "lblDefectLinkFieldId";
            this.lblDefectLinkFieldId.Size = new System.Drawing.Size(136, 13);
            this.lblDefectLinkFieldId.TabIndex = 0;
            this.lblDefectLinkFieldId.Text = "Link to VersionOne Field ID";
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.lblConnectionValidation);
            this.grpConnection.Controls.Add(this.btnVerify);
            this.grpConnection.Controls.Add(this.txtPassword);
            this.grpConnection.Controls.Add(this.lblPassword);
            this.grpConnection.Controls.Add(this.txtUserName);
            this.grpConnection.Controls.Add(this.lblUserName);
            this.grpConnection.Controls.Add(this.txtUrl);
            this.grpConnection.Controls.Add(this.lblUrl);
            this.grpConnection.Location = new System.Drawing.Point(12, 5);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(502, 121);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // lblConnectionValidation
            // 
            this.lblConnectionValidation.AutoSize = true;
            this.lblConnectionValidation.Location = new System.Drawing.Point(74, 89);
            this.lblConnectionValidation.Name = "lblConnectionValidation";
            this.lblConnectionValidation.Size = new System.Drawing.Size(81, 13);
            this.lblConnectionValidation.TabIndex = 6;
            this.lblConnectionValidation.Text = "Validation result";
            this.lblConnectionValidation.Visible = false;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(389, 82);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(67, 27);
            this.btnVerify.TabIndex = 7;
            this.btnVerify.Text = "Validate";
            this.btnVerify.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(330, 49);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(126, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(268, 52);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(77, 49);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(130, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 52);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Username";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(77, 20);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(379, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 23);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(48, 13);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "JIRA URL";
            // 
            // grpUpdate
            // 
            this.grpUpdate.Controls.Add(this.lblDefectLinkFieldId);
            this.grpUpdate.Controls.Add(this.txtDefectLinkFieldId);
            this.grpUpdate.Controls.Add(this.lblAssigneeStateChanged);
            this.grpUpdate.Controls.Add(this.txtAssigneeStateChanged);
            this.grpUpdate.Controls.Add(this.lblProgressWorkflow);
            this.grpUpdate.Controls.Add(this.txtProgressWorkflow);
            this.grpUpdate.Controls.Add(this.lblProgressWorkflowClosed);
            this.grpUpdate.Controls.Add(this.txtProgressWorkflowClosed);
            this.grpUpdate.Controls.Add(this.lblCommentCloseFieldId);
            this.grpUpdate.Controls.Add(this.lblCommentCreateFieldId);
            this.grpUpdate.Controls.Add(this.lblCreateFieldId);
            this.grpUpdate.Controls.Add(this.txtCreateFieldId);
            this.grpUpdate.Controls.Add(this.lblCreateFieldValue);
            this.grpUpdate.Controls.Add(this.txtCreateFieldValue);
            this.grpUpdate.Controls.Add(this.lblCloseFieldId);
            this.grpUpdate.Controls.Add(this.txtCloseFieldId);
            this.grpUpdate.Controls.Add(this.lblCloseFieldValue);
            this.grpUpdate.Controls.Add(this.txtCloseFieldValue);
            this.grpUpdate.Location = new System.Drawing.Point(11, 374);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(502, 209);
            this.grpUpdate.TabIndex = 3;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Update JIRA Issue";
            // 
            // lblAssigneeStateChanged
            // 
            this.lblAssigneeStateChanged.AutoSize = true;
            this.lblAssigneeStateChanged.Location = new System.Drawing.Point(12, 145);
            this.lblAssigneeStateChanged.Name = "lblAssigneeStateChanged";
            this.lblAssigneeStateChanged.Size = new System.Drawing.Size(124, 13);
            this.lblAssigneeStateChanged.TabIndex = 12;
            this.lblAssigneeStateChanged.Text = "Assignee State Changed";
            // 
            // txtAssigneeStateChanged
            // 
            this.txtAssigneeStateChanged.Location = new System.Drawing.Point(154, 141);
            this.txtAssigneeStateChanged.Name = "txtAssigneeStateChanged";
            this.txtAssigneeStateChanged.Size = new System.Drawing.Size(302, 20);
            this.txtAssigneeStateChanged.TabIndex = 8;
            // 
            // lblProgressWorkflow
            // 
            this.lblProgressWorkflow.AutoSize = true;
            this.lblProgressWorkflow.Location = new System.Drawing.Point(12, 178);
            this.lblProgressWorkflow.Name = "lblProgressWorkflow";
            this.lblProgressWorkflow.Size = new System.Drawing.Size(136, 13);
            this.lblProgressWorkflow.TabIndex = 14;
            this.lblProgressWorkflow.Text = "Progress Workflow Created";
            // 
            // txtProgressWorkflow
            // 
            this.txtProgressWorkflow.Location = new System.Drawing.Point(154, 174);
            this.txtProgressWorkflow.Name = "txtProgressWorkflow";
            this.txtProgressWorkflow.Size = new System.Drawing.Size(53, 20);
            this.txtProgressWorkflow.TabIndex = 10;
            // 
            // lblProgressWorkflowClosed
            // 
            this.lblProgressWorkflowClosed.AutoSize = true;
            this.lblProgressWorkflowClosed.Location = new System.Drawing.Point(269, 178);
            this.lblProgressWorkflowClosed.Name = "lblProgressWorkflowClosed";
            this.lblProgressWorkflowClosed.Size = new System.Drawing.Size(131, 13);
            this.lblProgressWorkflowClosed.TabIndex = 16;
            this.lblProgressWorkflowClosed.Text = "Progress Workflow Closed";
            // 
            // txtProgressWorkflowClosed
            // 
            this.txtProgressWorkflowClosed.Location = new System.Drawing.Point(403, 174);
            this.txtProgressWorkflowClosed.Name = "txtProgressWorkflowClosed";
            this.txtProgressWorkflowClosed.Size = new System.Drawing.Size(53, 20);
            this.txtProgressWorkflowClosed.TabIndex = 15;
            // 
            // lblCommentCloseFieldId
            // 
            this.lblCommentCloseFieldId.AutoSize = true;
            this.lblCommentCloseFieldId.BackColor = System.Drawing.SystemColors.Control;
            this.lblCommentCloseFieldId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCommentCloseFieldId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCommentCloseFieldId.Location = new System.Drawing.Point(12, 120);
            this.lblCommentCloseFieldId.Name = "lblCommentCloseFieldId";
            this.lblCommentCloseFieldId.Size = new System.Drawing.Size(157, 14);
            this.lblCommentCloseFieldId.TabIndex = 9;
            this.lblCommentCloseFieldId.Text = "\"customfield_\" plus numeric id";
            // 
            // lblCommentCreateFieldId
            // 
            this.lblCommentCreateFieldId.AutoSize = true;
            this.lblCommentCreateFieldId.BackColor = System.Drawing.SystemColors.Control;
            this.lblCommentCreateFieldId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCommentCreateFieldId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCommentCreateFieldId.Location = new System.Drawing.Point(12, 75);
            this.lblCommentCreateFieldId.Name = "lblCommentCreateFieldId";
            this.lblCommentCreateFieldId.Size = new System.Drawing.Size(157, 14);
            this.lblCommentCreateFieldId.TabIndex = 4;
            this.lblCommentCreateFieldId.Text = "\"customfield_\" plus numeric id";
            // 
            // lblCreateFieldId
            // 
            this.lblCreateFieldId.AutoSize = true;
            this.lblCreateFieldId.Location = new System.Drawing.Point(12, 57);
            this.lblCreateFieldId.Name = "lblCreateFieldId";
            this.lblCreateFieldId.Size = new System.Drawing.Size(77, 13);
            this.lblCreateFieldId.TabIndex = 0;
            this.lblCreateFieldId.Text = "Create Field ID";
            // 
            // txtCreateFieldId
            // 
            this.txtCreateFieldId.Location = new System.Drawing.Point(93, 53);
            this.txtCreateFieldId.Name = "txtCreateFieldId";
            this.txtCreateFieldId.Size = new System.Drawing.Size(114, 20);
            this.txtCreateFieldId.TabIndex = 1;
            // 
            // lblCreateFieldValue
            // 
            this.lblCreateFieldValue.AutoSize = true;
            this.lblCreateFieldValue.Location = new System.Drawing.Point(264, 57);
            this.lblCreateFieldValue.Name = "lblCreateFieldValue";
            this.lblCreateFieldValue.Size = new System.Drawing.Size(93, 13);
            this.lblCreateFieldValue.TabIndex = 2;
            this.lblCreateFieldValue.Text = "Create Field Value";
            // 
            // txtCreateFieldValue
            // 
            this.txtCreateFieldValue.Location = new System.Drawing.Point(368, 53);
            this.txtCreateFieldValue.Name = "txtCreateFieldValue";
            this.txtCreateFieldValue.Size = new System.Drawing.Size(88, 20);
            this.txtCreateFieldValue.TabIndex = 3;
            // 
            // lblCloseFieldId
            // 
            this.lblCloseFieldId.AutoSize = true;
            this.lblCloseFieldId.Location = new System.Drawing.Point(12, 101);
            this.lblCloseFieldId.Name = "lblCloseFieldId";
            this.lblCloseFieldId.Size = new System.Drawing.Size(72, 13);
            this.lblCloseFieldId.TabIndex = 5;
            this.lblCloseFieldId.Text = "Close Field ID";
            // 
            // txtCloseFieldId
            // 
            this.txtCloseFieldId.Location = new System.Drawing.Point(93, 97);
            this.txtCloseFieldId.Name = "txtCloseFieldId";
            this.txtCloseFieldId.Size = new System.Drawing.Size(114, 20);
            this.txtCloseFieldId.TabIndex = 6;
            // 
            // lblCloseFieldValue
            // 
            this.lblCloseFieldValue.AutoSize = true;
            this.lblCloseFieldValue.Location = new System.Drawing.Point(264, 101);
            this.lblCloseFieldValue.Name = "lblCloseFieldValue";
            this.lblCloseFieldValue.Size = new System.Drawing.Size(88, 13);
            this.lblCloseFieldValue.TabIndex = 7;
            this.lblCloseFieldValue.Text = "Close Field Value";
            // 
            // txtCloseFieldValue
            // 
            this.txtCloseFieldValue.Location = new System.Drawing.Point(368, 97);
            this.txtCloseFieldValue.Name = "txtCloseFieldValue";
            this.txtCloseFieldValue.Size = new System.Drawing.Size(88, 20);
            this.txtCloseFieldValue.TabIndex = 8;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.lblCreateDefectFilterId);
            this.grpSearch.Controls.Add(this.txtCreateDefectFilterId);
            this.grpSearch.Controls.Add(this.chkDefectFilterDisabled);
            this.grpSearch.Controls.Add(this.lblCreateStoryFilterId);
            this.grpSearch.Controls.Add(this.txtCreateStoryFilterId);
            this.grpSearch.Controls.Add(this.chkStoryFilterDisabled);
            this.grpSearch.Location = new System.Drawing.Point(12, 280);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(502, 86);
            this.grpSearch.TabIndex = 2;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Find JIRA Issues";
            // 
            // chkDefectFilterDisabled
            // 
            this.chkDefectFilterDisabled.AutoSize = true;
            this.chkDefectFilterDisabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDefectFilterDisabled.Location = new System.Drawing.Point(293, 21);
            this.chkDefectFilterDisabled.Name = "chkDefectFilterDisabled";
            this.chkDefectFilterDisabled.Size = new System.Drawing.Size(67, 17);
            this.chkDefectFilterDisabled.TabIndex = 2;
            this.chkDefectFilterDisabled.Text = "Disabled";
            this.chkDefectFilterDisabled.UseVisualStyleBackColor = true;
            // 
            // lblCreateStoryFilterId
            // 
            this.lblCreateStoryFilterId.AutoSize = true;
            this.lblCreateStoryFilterId.Location = new System.Drawing.Point(12, 54);
            this.lblCreateStoryFilterId.Name = "lblCreateStoryFilterId";
            this.lblCreateStoryFilterId.Size = new System.Drawing.Size(104, 13);
            this.lblCreateStoryFilterId.TabIndex = 3;
            this.lblCreateStoryFilterId.Text = "Create Story Filter ID";
            // 
            // txtCreateStoryFilterId
            // 
            this.txtCreateStoryFilterId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreateStoryFilterId.Location = new System.Drawing.Point(130, 50);
            this.txtCreateStoryFilterId.Name = "txtCreateStoryFilterId";
            this.txtCreateStoryFilterId.Size = new System.Drawing.Size(115, 20);
            this.txtCreateStoryFilterId.TabIndex = 4;
            // 
            // chkStoryFilterDisabled
            // 
            this.chkStoryFilterDisabled.AutoSize = true;
            this.chkStoryFilterDisabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStoryFilterDisabled.Location = new System.Drawing.Point(293, 52);
            this.chkStoryFilterDisabled.Name = "chkStoryFilterDisabled";
            this.chkStoryFilterDisabled.Size = new System.Drawing.Size(67, 17);
            this.chkStoryFilterDisabled.TabIndex = 5;
            this.chkStoryFilterDisabled.Text = "Disabled";
            this.chkStoryFilterDisabled.UseVisualStyleBackColor = true;
            // 
            // grpProjectMappings
            // 
            this.grpProjectMappings.Controls.Add(this.btnDeleteProjectMapping);
            this.grpProjectMappings.Controls.Add(this.grdProjectMappings);
            this.grpProjectMappings.Location = new System.Drawing.Point(6, 9);
            this.grpProjectMappings.Name = "grpProjectMappings";
            this.grpProjectMappings.Size = new System.Drawing.Size(508, 236);
            this.grpProjectMappings.TabIndex = 0;
            this.grpProjectMappings.TabStop = false;
            this.grpProjectMappings.Text = "Project Mappings";
            // 
            // btnDeleteProjectMapping
            // 
            this.btnDeleteProjectMapping.Image = global::VersionOne.ServiceHost.ConfigurationTool.Resources.DeleteIcon;
            this.btnDeleteProjectMapping.Location = new System.Drawing.Point(330, 195);
            this.btnDeleteProjectMapping.Name = "btnDeleteProjectMapping";
            this.btnDeleteProjectMapping.Size = new System.Drawing.Size(132, 26);
            this.btnDeleteProjectMapping.TabIndex = 1;
            this.btnDeleteProjectMapping.Text = "Delete selected row";
            this.btnDeleteProjectMapping.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteProjectMapping.UseVisualStyleBackColor = true;
            // 
            // grdProjectMappings
            // 
            this.grdProjectMappings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProjectMappings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVersionOneProject,
            this.colJiraProject});
            this.grdProjectMappings.Location = new System.Drawing.Point(15, 20);
            this.grdProjectMappings.MultiSelect = false;
            this.grdProjectMappings.Name = "grdProjectMappings";
            this.grdProjectMappings.Size = new System.Drawing.Size(447, 169);
            this.grdProjectMappings.TabIndex = 0;
            // 
            // colVersionOneProject
            // 
            this.colVersionOneProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVersionOneProject.DataPropertyName = "VersionOneProjectToken";
            this.colVersionOneProject.HeaderText = "VersionOne Project";
            this.colVersionOneProject.MinimumWidth = 110;
            this.colVersionOneProject.Name = "colVersionOneProject";
            // 
            // colJiraProject
            // 
            this.colJiraProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colJiraProject.DataPropertyName = "JiraProjectName";
            this.colJiraProject.HeaderText = "JIRA Project";
            this.colJiraProject.MinimumWidth = 100;
            this.colJiraProject.Name = "colJiraProject";
            // 
            // tcJiraData
            // 
            this.tcJiraData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcJiraData.Controls.Add(this.tpSettings);
            this.tcJiraData.Controls.Add(this.tpMappings);
            this.tcJiraData.Location = new System.Drawing.Point(0, 34);
            this.tcJiraData.Name = "tcJiraData";
            this.tcJiraData.SelectedIndex = 0;
            this.tcJiraData.Size = new System.Drawing.Size(564, 673);
            this.tcJiraData.TabIndex = 1;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.grpConnection);
            this.tpSettings.Controls.Add(this.lblMinutes);
            this.tpSettings.Controls.Add(this.grpVersionOneDefectAttributes);
            this.tpSettings.Controls.Add(this.lblTimerInterval);
            this.tpSettings.Controls.Add(this.grpUpdate);
            this.tpSettings.Controls.Add(this.nmdInterval);
            this.tpSettings.Controls.Add(this.grpSearch);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(556, 647);
            this.tpSettings.TabIndex = 0;
            this.tpSettings.Text = "JIRA Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // tpMappings
            // 
            this.tpMappings.Controls.Add(this.grpPriorityMappings);
            this.tpMappings.Controls.Add(this.grpProjectMappings);
            this.tpMappings.Location = new System.Drawing.Point(4, 22);
            this.tpMappings.Name = "tpMappings";
            this.tpMappings.Padding = new System.Windows.Forms.Padding(3);
            this.tpMappings.Size = new System.Drawing.Size(556, 647);
            this.tpMappings.TabIndex = 1;
            this.tpMappings.Text = "Project and Priority Mappings";
            this.tpMappings.UseVisualStyleBackColor = true;
            // 
            // grpPriorityMappings
            // 
            this.grpPriorityMappings.Controls.Add(this.lblPriorityValidationNote);
            this.grpPriorityMappings.Controls.Add(this.btnDeletePriorityMapping);
            this.grpPriorityMappings.Controls.Add(this.grdPriorityMappings);
            this.grpPriorityMappings.Location = new System.Drawing.Point(12, 251);
            this.grpPriorityMappings.Name = "grpPriorityMappings";
            this.grpPriorityMappings.Size = new System.Drawing.Size(502, 254);
            this.grpPriorityMappings.TabIndex = 1;
            this.grpPriorityMappings.TabStop = false;
            this.grpPriorityMappings.Text = "Priority Mappings";
            // 
            // lblPriorityValidationNote
            // 
            this.lblPriorityValidationNote.AutoSize = true;
            this.lblPriorityValidationNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPriorityValidationNote.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblPriorityValidationNote.Location = new System.Drawing.Point(15, 196);
            this.lblPriorityValidationNote.Name = "lblPriorityValidationNote";
            this.lblPriorityValidationNote.Size = new System.Drawing.Size(310, 13);
            this.lblPriorityValidationNote.TabIndex = 2;
            this.lblPriorityValidationNote.Text = "*Please validate connection to JIRA for proper priority assignment.";
            // 
            // btnDeletePriorityMapping
            // 
            this.btnDeletePriorityMapping.Image = global::VersionOne.ServiceHost.ConfigurationTool.Resources.DeleteIcon;
            this.btnDeletePriorityMapping.Location = new System.Drawing.Point(324, 222);
            this.btnDeletePriorityMapping.Name = "btnDeletePriorityMapping";
            this.btnDeletePriorityMapping.Size = new System.Drawing.Size(132, 26);
            this.btnDeletePriorityMapping.TabIndex = 1;
            this.btnDeletePriorityMapping.Text = "Delete selected row";
            this.btnDeletePriorityMapping.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletePriorityMapping.UseVisualStyleBackColor = true;
            // 
            // grdPriorityMappings
            // 
            this.grdPriorityMappings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPriorityMappings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVersionOnePriority,
            this.colJiraPriority});
            this.grdPriorityMappings.Location = new System.Drawing.Point(15, 20);
            this.grdPriorityMappings.MultiSelect = false;
            this.grdPriorityMappings.Name = "grdPriorityMappings";
            this.grdPriorityMappings.Size = new System.Drawing.Size(441, 169);
            this.grdPriorityMappings.TabIndex = 0;
            // 
            // colVersionOnePriority
            // 
            this.colVersionOnePriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVersionOnePriority.DataPropertyName = "VersionOnePriorityId";
            this.colVersionOnePriority.HeaderText = "VersionOne Priority";
            this.colVersionOnePriority.MinimumWidth = 100;
            this.colVersionOnePriority.Name = "colVersionOnePriority";
            // 
            // colJiraPriority
            // 
            this.colJiraPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colJiraPriority.DataPropertyName = "JiraPriorityId";
            this.colJiraPriority.HeaderText = "JIRA Priority";
            this.colJiraPriority.MinimumWidth = 100;
            this.colJiraPriority.Name = "colJiraPriority";
            // 
            // JiraPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcJiraData);
            this.Controls.Add(this.chkDisabled);
            this.Name = "JiraPageControl";
            this.Size = new System.Drawing.Size(540, 742);
            this.grpVersionOneDefectAttributes.ResumeLayout(false);
            this.grpVersionOneDefectAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmdInterval)).EndInit();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpUpdate.ResumeLayout(false);
            this.grpUpdate.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpProjectMappings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProjectMappings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProjectMappings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPriorityMappings)).EndInit();
            this.tcJiraData.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.tpMappings.ResumeLayout(false);
            this.grpPriorityMappings.ResumeLayout(false);
            this.grpPriorityMappings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPriorityMappings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDisabled;
        private System.Windows.Forms.GroupBox grpVersionOneDefectAttributes;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblTimerInterval;
        private System.Windows.Forms.NumericUpDown nmdInterval;
        private System.Windows.Forms.ComboBox cboSourceFieldValue;
        private System.Windows.Forms.TextBox txtJiraUrlTitle;
        private System.Windows.Forms.Label lblJiraUrlTitle;
        private System.Windows.Forms.TextBox txtJiraUrlTempl;
        private System.Windows.Forms.Label lblJiraUrlTempl;
        private System.Windows.Forms.TextBox txtCreateDefectFilterId;
        private System.Windows.Forms.Label lblCreateDefectFilterId;
        private System.Windows.Forms.TextBox txtDefectLinkFieldId;
        private System.Windows.Forms.Label lblDefectLinkFieldId;
        private System.Windows.Forms.Label lblSourceFieldValue;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label lblConnectionValidation;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.GroupBox grpProjectMappings;
        private System.Windows.Forms.DataGridView grdProjectMappings;
        private System.Windows.Forms.Button btnDeleteProjectMapping;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.BindingSource bsProjectMappings;
        private System.Windows.Forms.BindingSource bsPriorityMappings;
        private TabControl tcJiraData;
        private TabPage tpSettings;
        private TabPage tpMappings;
        private GroupBox grpPriorityMappings;
        private Button btnDeletePriorityMapping;
        private DataGridView grdPriorityMappings;
        private Label lblPriorityValidationNote;
        private DataGridViewComboBoxColumn colVersionOneProject;
        private DataGridViewTextBoxColumn colJiraProject;
        private DataGridViewComboBoxColumn colVersionOnePriority;
        private DataGridViewComboBoxColumn colJiraPriority;
        private CheckBox chkStoryFilterDisabled;
        private Label lblCreateStoryFilterId;
        private TextBox txtCreateStoryFilterId;
        private CheckBox chkDefectFilterDisabled;
        private Label lblAssigneeStateChanged;
        private TextBox txtAssigneeStateChanged;
        private Label lblProgressWorkflow;
        private TextBox txtProgressWorkflow;
        private Label lblProgressWorkflowClosed;
        private TextBox txtProgressWorkflowClosed;
        private Label lblCommentCloseFieldId;
        private Label lblCommentCreateFieldId;
        private Label lblCreateFieldId;
        private Label lblCreateFieldValue;
        private TextBox txtCreateFieldId;
        private Label lblCloseFieldId;
        private TextBox txtCreateFieldValue;
        private Label lblCloseFieldValue;
        private TextBox txtCloseFieldId;
        private TextBox txtCloseFieldValue;
    }
}