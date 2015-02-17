using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VersionOne.ServiceHost.ConfigurationTool.DL;
using VersionOne.ServiceHost.ConfigurationTool.Entities;
using VersionOne.ServiceHost.ConfigurationTool.UI.Interfaces;
using VersionOne.ServiceHost.ConfigurationTool.BZ;

namespace VersionOne.ServiceHost.ConfigurationTool.UI.Controls {
    public partial class JiraPageControl : /*UserControl { //*/BasePageControl<JiraServiceEntity>, IJiraPageView {
        private IList<ListValue> jiraPriorities;

        public event EventHandler ValidationRequested;

        public JiraPageControl() {
            InitializeComponent();
            grdProjectMappings.AutoGenerateColumns = false;
            grdPriorityMappings.AutoGenerateColumns = false;

            AddTabHighlightingSupport(tcJiraData);

            btnVerify.Click += btnVerifyJiraConnection_Click;
            btnDeleteProjectMapping.Click += btnDeleteProjectMapping_Click;
            btnDeletePriorityMapping.Click += btnDeletePriorityMapping_Click;

            grdProjectMappings.UserDeletingRow += delegate(object sender, DataGridViewRowCancelEventArgs e) {
                if(!ConfirmDelete()) {
                    e.Cancel = true;
                }
            };
            grdPriorityMappings.UserDeletingRow += delegate(object sender, DataGridViewRowCancelEventArgs e) {
                if(!ConfirmDelete()) {
                    e.Cancel = true;
                }
            };
            grdProjectMappings.DataError += grdProjectMappings_DataError;
            grdPriorityMappings.DataError += grdPriorityMappings_DataError;

            AddGridValidationProvider(typeof(JiraProjectMapping), grdProjectMappings);
            AddGridValidationProvider(typeof(JiraPriorityMapping), grdPriorityMappings);
            AddValidationProvider(typeof(JiraFilter));

            AddControlTextValidation<JiraServiceEntity>(txtUrl, JiraServiceEntity.UrlProperty);
            AddControlTextValidation<JiraServiceEntity>(txtJiraUrlTempl, JiraServiceEntity.UrlTemplateProperty);
            AddControlTextValidation<JiraServiceEntity>(txtUserName, JiraServiceEntity.UserNameProperty);
            AddControlTextValidation<JiraServiceEntity>(txtPassword, JiraServiceEntity.PasswordProperty);
            AddControlTextValidation<JiraFilter>(txtCreateDefectFilterId, JiraFilter.IdProperty);
            AddControlTextValidation<JiraFilter>(txtCreateStoryFilterId, JiraFilter.IdProperty);
            AddControlTextValidation<JiraServiceEntity>(cboSourceFieldValue, JiraServiceEntity.SourceNameProperty);

            toolTip.SetToolTip(btnDeleteProjectMapping, "Delete selected project mapping");
            toolTip.SetToolTip(btnDeletePriorityMapping, "Delete selected priority mapping");

            bsPriorityMappings.CurrentItemChanged += bsPriorityMappings_CurrentItemChanged;
            chkDefectFilterDisabled.CheckStateChanged += chkDefectFilterEnabled_CheckStateChanged;
            chkStoryFilterDisabled.CheckStateChanged += chkStoryFilterEnabled_CheckStateChanged;
        }

        private void chkStoryFilterEnabled_CheckStateChanged(object sender, EventArgs e) {
            SwitchStoryFilterEnableState();
        }

        private void chkDefectFilterEnabled_CheckStateChanged(object sender, EventArgs e) {
            SwitchDefectFilterEnableState();
        }

        private void bsPriorityMappings_CurrentItemChanged(object sender, EventArgs e) {
            var current = (JiraPriorityMapping) bsPriorityMappings.Current;

            if(current == null) {
                return;
            }

            var currentId = current.JiraPriorityId;
            var sourceName = (jiraPriorities.Where(item => item.Value == currentId).Select(item=> item.Name).FirstOrDefault()) ?? string.Empty;

            if(!string.IsNullOrEmpty(sourceName) && current.JiraPriorityName != sourceName) {
                current.JiraPriorityName = sourceName;
            }
        }

        public override void DataBind() {
            AddControlBinding(chkDisabled, Model, BaseEntity.DisabledProperty);
            AddControlBinding(txtUrl, Model, JiraServiceEntity.UrlProperty);
            AddControlBinding(txtPassword, Model, JiraServiceEntity.PasswordProperty);
            AddControlBinding(txtUserName, Model, JiraServiceEntity.UserNameProperty);
            AddControlBinding(txtCreateDefectFilterId, Model.CreateDefectFilter, JiraFilter.IdProperty);
            AddControlBinding(chkDefectFilterDisabled, Model.CreateDefectFilter, JiraFilter.DisabledProperty);
            AddControlBinding(txtCreateStoryFilterId, Model.CreateStoryFilter, JiraFilter.IdProperty);
            AddControlBinding(chkStoryFilterDisabled, Model.CreateStoryFilter, JiraFilter.DisabledProperty);
            AddControlBinding(txtJiraUrlTitle, Model, JiraServiceEntity.UrlTitleProperty);
            AddControlBinding(txtJiraUrlTempl, Model, JiraServiceEntity.UrlTemplateProperty);
            AddSimpleComboboxBinding(cboSourceFieldValue, Model, JiraServiceEntity.SourceNameProperty);
            AddControlBinding(txtDefectLinkFieldId, Model, JiraServiceEntity.LinkFieldProperty);
            AddControlBinding(nmdInterval, Model.Timer, TimerEntity.TimerProperty);
            AddControlBinding(txtCreateFieldValue, Model, JiraServiceEntity.CreateFieldValueProperty);
            AddControlBinding(txtCreateFieldId, Model, JiraServiceEntity.CreateFieldIdProperty);
            AddControlBinding(txtCloseFieldValue, Model, JiraServiceEntity.CloseFieldValueProperty);
            AddControlBinding(txtCloseFieldId, Model, JiraServiceEntity.CloseFieldIdProperty);
            AddControlBinding(txtAssigneeStateChanged, Model, JiraServiceEntity.AssigneeStateChangedProperty);
            AddControlBinding(txtProgressWorkflow, Model.ProgressWorkflow, NullableInt.StringValueProperty);
            AddControlBinding(txtProgressWorkflowClosed, Model.ProgressWorkflowClosed, NullableInt.StringValueProperty);

            BindProjectMappingsGrid();
            BindPriorityMappingsGrid();

            BindHelpStrings();

            FillComboBoxWithStrings(cboSourceFieldValue, AvailableSources);

            SwitchDefectFilterEnableState();
            SwitchStoryFilterEnableState();
            InvokeValidationTriggered();
        }

        private void BindPriorityMappingsGrid() {
            BindVersionOnePriorityColumn();
            jiraPriorities = CreateDataSourceFromMappings(Model.PriorityMappings);
            BindJiraPriorityColumn();
            bsPriorityMappings.DataSource = Model.PriorityMappings;
            grdPriorityMappings.DataSource = bsPriorityMappings;
        }

        private void BindProjectMappingsGrid() {
            BindProjectColumn();
            bsProjectMappings.DataSource = Model.ProjectMappings;
            grdProjectMappings.DataSource = bsProjectMappings;
        }

        private void SwitchStoryFilterEnableState() {
            txtCreateStoryFilterId.Enabled = !chkStoryFilterDisabled.Checked;
        }

        private void SwitchDefectFilterEnableState() {
            txtCreateDefectFilterId.Enabled = !chkDefectFilterDisabled.Checked;
        }

        private void BindHelpStrings() {
            AddHelpSupport(lblMinutes, Model.Timer, TimerEntity.TimerProperty);
            AddHelpSupport(chkDisabled, Model, BaseEntity.DisabledProperty);
            AddHelpSupport(txtCreateDefectFilterId, Model.CreateDefectFilter, JiraFilter.IdProperty);
            AddHelpSupport(chkDefectFilterDisabled, Model.CreateDefectFilter, JiraFilter.DisabledProperty);
            AddHelpSupport(txtCreateStoryFilterId, Model.CreateStoryFilter, JiraFilter.IdProperty);
            AddHelpSupport(chkStoryFilterDisabled, Model.CreateStoryFilter, JiraFilter.DisabledProperty);
            AddHelpSupport(txtDefectLinkFieldId, Model, JiraServiceEntity.LinkFieldProperty);
            AddHelpSupport(txtJiraUrlTempl, Model, JiraServiceEntity.UrlTemplateProperty);
            AddHelpSupport(cboSourceFieldValue, Model, JiraServiceEntity.SourceNameProperty);
            AddHelpSupport(grdProjectMappings, Model, JiraServiceEntity.ProjectMappingsProperty);
            AddHelpSupport(grdPriorityMappings, Model, JiraServiceEntity.PriorityMappingsProperty);
            AddHelpSupport(txtCreateFieldValue, Model, JiraServiceEntity.CreateFieldValueProperty);
            AddHelpSupport(txtCreateFieldId, Model, JiraServiceEntity.CreateFieldIdProperty);
            AddHelpSupport(txtCloseFieldValue, Model, JiraServiceEntity.CloseFieldValueProperty);
            AddHelpSupport(txtCloseFieldId, Model, JiraServiceEntity.CloseFieldIdProperty);
            AddHelpSupport(txtAssigneeStateChanged, Model, JiraServiceEntity.AssigneeStateChangedProperty);
            AddHelpSupport(txtProgressWorkflow, Model, JiraServiceEntity.ProgressWorkflowProperty);
            AddHelpSupport(txtProgressWorkflowClosed, Model, JiraServiceEntity.ProgressWorkflowClosedProperty);
        }

        private static IList<ListValue> CreateDataSourceFromMappings(IEnumerable<JiraPriorityMapping> mappings) {
            return mappings.Select(mapping => new ListValue(mapping.JiraPriorityName, mapping.JiraPriorityId)).ToList();
        }

        private void BindProjectColumn() {
            colVersionOneProject.DisplayMember = "DisplayName";
            colVersionOneProject.ValueMember = "Token";
            colVersionOneProject.DataSource = ProjectWrapperList;
        }

        private void BindVersionOnePriorityColumn() {
            colVersionOnePriority.DisplayMember = "Name";
            colVersionOnePriority.ValueMember = "Value";
            colVersionOnePriority.DataSource = VersionOnePriorities;
        }

        private void BindJiraPriorityColumn() {
            colJiraPriority.DisplayMember = "Name";
            colJiraPriority.ValueMember = "Value";
            colJiraPriority.DataSource = jiraPriorities;
        }

        private void btnVerifyJiraConnection_Click(object sender, EventArgs e) {
            if(ValidationRequested != null) {
                ValidationRequested(this, EventArgs.Empty);
            }
        }

        private void btnDeleteProjectMapping_Click(object sender, EventArgs e) {
            if(grdProjectMappings.SelectedRows.Count > 0 && ConfirmDelete()) {
                bsProjectMappings.Remove(grdProjectMappings.SelectedRows[0].DataBoundItem);
            }
        }

        private void btnDeletePriorityMapping_Click(object sender, EventArgs e) {
            if(grdPriorityMappings.SelectedRows.Count > 0 && ConfirmDelete()) {
                bsPriorityMappings.Remove(grdPriorityMappings.SelectedRows[0].DataBoundItem);
            }
        }

        private void grdProjectMappings_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            if(ProjectWrapperList != null && ProjectWrapperList.Count > 0) {
                grdProjectMappings.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ProjectWrapperList[0].Token;
            }

            e.ThrowException = false;
        }

        private void grdPriorityMappings_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            var column = grdPriorityMappings.Columns[e.ColumnIndex];

            if(column == colVersionOnePriority) {
                SetDefaultValue(VersionOnePriorities, e.RowIndex, e.ColumnIndex);
            } else if(column == colJiraPriority) {
                SetDefaultValue(jiraPriorities, e.RowIndex, e.ColumnIndex);
            }

            e.ThrowException = false;
        }

        private void SetDefaultValue(IList<ListValue> dataSource, int rowIndex, int columnIndex) {
            if(dataSource != null && dataSource.Count > 0) {
                grdPriorityMappings.Rows[rowIndex].Cells[columnIndex].Value = dataSource[0].Value;
            }
        }

        public void SetValidationResult(bool validationSuccessful) {
            lblConnectionValidation.Visible = true;

            if(validationSuccessful) {
                lblConnectionValidation.ForeColor = Color.Green;
                lblConnectionValidation.Text = Resources.ConnectionValidMessage
                                                + Environment.NewLine
                                                + Resources.CheckPriorityMappingsMessage;
            } else {
                lblConnectionValidation.ForeColor = Color.Red;
                lblConnectionValidation.Text = Resources.ConnectionInvalidMessage;
            }
        }

        public IEnumerable<string> AvailableSources { get; set; }

        public IList<ProjectWrapper> ProjectWrapperList { get; set; }

        public IList<ListValue> VersionOnePriorities { get; set; }

        public void SetGeneralTabValidity(bool isValid) {
            TabHighlighter.SetTabPageValidationMark(tpSettings, isValid);
        }

        public void SetMappingTabValidity(bool isValid) {
            TabHighlighter.SetTabPageValidationMark(tpMappings, isValid);
        }

        public void UpdateJiraPriorities(IList<ListValue> priorities) {
            jiraPriorities = priorities;
            BindJiraPriorityColumn();
        }
    }
}