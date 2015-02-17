using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using VersionOne.ServiceHost.ConfigurationTool.Attributes;
using VersionOne.ServiceHost.ConfigurationTool.Validation;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities {
    [DependsOnVersionOne]
    [DependsOnService(typeof(WorkitemWriterEntity))]
    [XmlRoot("JiraHostedService")]
    [HasSelfValidation]
    public class JiraServiceEntity : BaseServiceEntity {
        private const string jiraServiceFactory = "VersionOne.Jira.SoapProxy.JiraSoapServiceFactory, VersionOne.Jira.SoapProxy";

        public const string UrlProperty = "Url";
        public const string UserNameProperty = "UserName";
        public const string PasswordProperty = "Password";
        public const string CreateDefectFilterProperty = "CreateDefectFilter";
        public const string CreateStoryFilterProperty = "CreateStoryFilter";
        public const string CreateFieldIdProperty = "CreateFieldId";
        public const string CreateFieldValueProperty = "CreateFieldValue";
        public const string CloseFieldIdProperty = "CloseFieldId";
        public const string CloseFieldValueProperty = "CloseFieldValue";
        public const string ProgressWorkflowProperty = "ProgressWorkflow";
        public const string ProgressWorkflowClosedProperty = "ProgressWorkflowClosed";
        public const string AssigneeStateChangedProperty = "AssigneeStateChanged";
        public const string UrlTemplateProperty = "UrlTemplate";
        public const string UrlTitleProperty = "UrlTitle";
        public const string SourceNameProperty = "SourceName";
        public const string LinkFieldProperty = "LinkField";
        public const string JiraServiceFactoryProperty = "JIRAServiceFactory";
        public const string ProjectMappingsProperty = "ProjectMappings";
        public const string PriorityMappingsProperty = "PriorityMappings";

        public JiraServiceEntity () {
            CreateTimer(TimerEntity.DefaultTimerIntervalMinutes);
            CreateDefectFilter = new JiraFilter();
            CreateStoryFilter = new JiraFilter();
            ProgressWorkflow = new NullableInt();
            ProgressWorkflowClosed = new NullableInt();
            ProjectMappings = new List<JiraProjectMapping>();
            PriorityMappings = new List<JiraPriorityMapping>();
        }

        [XmlElement("JIRAServiceFactory")]
        public string JiraServiceFactory {
            get { return jiraServiceFactory; }
            set {}
        }

        [NonEmptyStringValidator]
        [XmlElement("JIRAUrl")]
        public string Url { get; set; }

        [NonEmptyStringValidator]
        [XmlElement("JIRAUserName")]
        public string UserName { get; set; }

        [NonEmptyStringValidator]
        [XmlElement("JIRAPassword")]
        public string Password { get; set; }

        [XmlArray("ProjectMappings")]
        [XmlArrayItem("Mapping")]
        [HelpString(HelpResourceKey = "JiraProjectMappings")]
        public List<JiraProjectMapping> ProjectMappings { get; set; }

        [XmlArray("PriorityMappings")]
        [XmlArrayItem("Mapping")]
        [HelpString(HelpResourceKey = "JiraPriorityMappings")]
        public List<JiraPriorityMapping> PriorityMappings { get; set; }

        [XmlElement("CreateDefectFilter")]
        [ObjectValidator]
        public JiraFilter CreateDefectFilter { get; set; }

        [XmlElement("CreateStoryFilter")]
        [ObjectValidator]
        public JiraFilter CreateStoryFilter { get; set; }

        [HelpString(HelpResourceKey = "JiraCreateFieldId")]
        public string CreateFieldId { get; set; }

        [HelpString(HelpResourceKey = "JiraCreateFieldValue")]
        public string CreateFieldValue { get; set; }

        [HelpString(HelpResourceKey = "JiraCloseFieldId")]
        public string CloseFieldId { get; set; }

        [HelpString(HelpResourceKey = "JiraCloseFieldValue")]
        public string CloseFieldValue { get; set; }

        [HelpString(HelpResourceKey = "JiraProgressWorkflow")]
        public NullableInt ProgressWorkflow { get; set; }

        [HelpString(HelpResourceKey = "JiraProgressWorkflowClosed")]
        public NullableInt ProgressWorkflowClosed { get; set; }

        [HelpString(HelpResourceKey = "JiraAssigneeStateChanged")]
        public string AssigneeStateChanged { get; set; }

        [NonEmptyStringValidator]
        [RegexValidator(@"^[a-z]+:\/\/.+?\#key\#$", MessageTemplate = "URL must be valid and end with #key# pattern.")]
        [XmlElement("JIRAIssueUrlTemplate")]
        [HelpString(HelpResourceKey = "JiraIssueUrlTemplate")]
        public string UrlTemplate { get; set; }

        [XmlElement("JIRAIssueUrlTitle")]
        public string UrlTitle { get; set; }

        [NonEmptyStringValidator]
        [XmlElement("SourceFieldValue")]
        [HelpString(HelpResourceKey = "JiraSourceFieldValue")]
        public string SourceName { get; set; }

        [XmlElement("WorkitemLinkFieldId")]
        [HelpString(HelpResourceKey = "JiraWorkitemLinkFieldId")]
        public string LinkField { get; set; }

        [SelfValidation]
        public void CheckProjectMappings(ValidationResults results) {
            var validator = ValidationFactory.CreateValidator<JiraProjectMapping>();

            foreach(var mapping in ProjectMappings) {
                var mappingValidationResults = validator.Validate(mapping);

                if(!mappingValidationResults.IsValid) {
                    results.AddAllResults(mappingValidationResults);
                }
            }
        }

        [SelfValidation]
        public void CheckPriorityMappings(ValidationResults results) {
            var validator = ValidationFactory.CreateValidator<JiraPriorityMapping>();

            foreach (var mapping in PriorityMappings) {
                var mappingValidationResults = validator.Validate(mapping);

                if(!mappingValidationResults.IsValid) {
                    results.AddAllResults(mappingValidationResults);
                }
            }
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            var other = (JiraServiceEntity) obj;

            return string.Equals(other.AssigneeStateChanged, AssigneeStateChanged) &&
                string.Equals(other.CloseFieldId, CloseFieldId) && string.Equals(other.CloseFieldValue, CloseFieldValue) &&
                string.Equals(other.CreateFieldId, CreateFieldId) &&
                string.Equals(other.CreateFieldValue, CreateFieldValue) &&
                CreateDefectFilter.Equals(other.CreateDefectFilter) &&
                string.Equals(other.LinkField, LinkField) &&
                string.Equals(other.Password, Password) &&
                ProgressWorkflow.Equals(other.ProgressWorkflow) &&
                ProgressWorkflowClosed.Equals(other.ProgressWorkflowClosed) &&
                string.Equals(other.SourceName, SourceName) &&
                string.Equals(other.UserName, UserName) &&
                string.Equals(other.Url, Url) &&
                string.Equals(other.UrlTemplate, UrlTemplate) &&
                string.Equals(other.UrlTitle, UrlTitle);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}