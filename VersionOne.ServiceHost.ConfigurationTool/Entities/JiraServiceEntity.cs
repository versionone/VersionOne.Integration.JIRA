using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using VersionOne.ServiceHost.ConfigurationTool.Attributes;
using VersionOne.ServiceHost.ConfigurationTool.Validation;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    [DependsOnVersionOne]
    [DependsOnService(typeof(WorkitemWriterEntity))]
    [XmlRoot("JiraHostedService")]
    [HasSelfValidation]
    public class JiraServiceEntity : BaseServiceEntity
    {
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

        private string url;
        private string userName;
        private string password;
        private ObservableCollection<JiraProjectMapping> projectMappings;
        private ObservableCollection<JiraPriorityMapping> priorityMappings;
        private JiraFilter createDefectFilter;
        private JiraFilter createStoryFilter;
        private string createFieldId;
        private string createFieldValue;
        private string closeFieldId;
        private string closeFieldValue;
        private NullableInt progressWorkflow;
        private NullableInt progressWorkflowClosed;
        private string assigneeStateChanged;
        private string urlTemplate;
        private string urlTitle;
        private string sourceName;
        private string linkField;

        public JiraServiceEntity()
        {
            CreateTimer(TimerEntity.DefaultTimerIntervalMinutes);
            CreateDefectFilter = new JiraFilter();
            CreateStoryFilter = new JiraFilter();
            ProgressWorkflow = new NullableInt();
            ProgressWorkflowClosed = new NullableInt();
            ProjectMappings = new ObservableCollection<JiraProjectMapping>();
            PriorityMappings = new ObservableCollection<JiraPriorityMapping>();
        }

        [XmlElement("JIRAServiceFactory")]
        public string JiraServiceFactory
        {
            get { return jiraServiceFactory; }
            set { }
        }

        [NonEmptyStringValidator]
        [XmlElement("JIRAUrl")]
        public string Url
        {
            get { return url; }
            set
            {
                if (url != value)
                {
                    url = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NonEmptyStringValidator]
        [XmlElement("JIRAUserName")]
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NonEmptyStringValidator]
        [XmlElement("JIRAPassword")]
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlArray("ProjectMappings")]
        [XmlArrayItem("Mapping")]
        [HelpString(HelpResourceKey = "JiraProjectMappings")]
        public ObservableCollection<JiraProjectMapping> ProjectMappings
        {
            get { return projectMappings; }
            set
            {
                if (projectMappings != value)
                {
                    projectMappings = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlArray("PriorityMappings")]
        [XmlArrayItem("Mapping")]
        [HelpString(HelpResourceKey = "JiraPriorityMappings")]
        public ObservableCollection<JiraPriorityMapping> PriorityMappings
        {
            get { return priorityMappings; }
            set
            {
                if (priorityMappings != value)
                {
                    priorityMappings = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlElement("CreateDefectFilter")]
        [ObjectValidator]
        public JiraFilter CreateDefectFilter
        {
            get { return createDefectFilter; }
            set
            {
                if (createDefectFilter != value)
                {
                    createDefectFilter = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlElement("CreateStoryFilter")]
        [ObjectValidator]
        public JiraFilter CreateStoryFilter
        {
            get { return createStoryFilter; }
            set
            {
                if (createStoryFilter != value)
                {
                    createStoryFilter = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [HelpString(HelpResourceKey = "JiraCreateFieldId")]
        public string CreateFieldId
        {
            get { return createFieldId; }
            set
            {
                if (createFieldId != value)
                {
                    createFieldId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [HelpString(HelpResourceKey = "JiraCreateFieldValue")]
        public string CreateFieldValue
        {
            get { return createFieldValue; }
            set
            {
                if (createFieldValue != value)
                {
                    createFieldValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [HelpString(HelpResourceKey = "JiraCloseFieldId")]
        public string CloseFieldId
        {
            get { return closeFieldId; }
            set
            {
                if (closeFieldId != value)
                {
                    closeFieldId = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [HelpString(HelpResourceKey = "JiraCloseFieldValue")]
        public string CloseFieldValue
        {
            get { return closeFieldValue; }
            set
            {
                if (closeFieldValue != value)
                {
                    closeFieldValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [HelpString(HelpResourceKey = "JiraProgressWorkflow")]
        public NullableInt ProgressWorkflow
        {
            get { return progressWorkflow; }
            set
            {
                if (progressWorkflow != value)
                {
                    progressWorkflow = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [HelpString(HelpResourceKey = "JiraProgressWorkflowClosed")]
        public NullableInt ProgressWorkflowClosed
        {
            get { return progressWorkflowClosed; }
            set
            {
                if (progressWorkflowClosed != value)
                {
                    progressWorkflowClosed = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [HelpString(HelpResourceKey = "JiraAssigneeStateChanged")]
        public string AssigneeStateChanged
        {
            get { return assigneeStateChanged; }
            set
            {
                if (assigneeStateChanged != value)
                {
                    assigneeStateChanged = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NonEmptyStringValidator]
        [RegexValidator(@"^[a-z]+:\/\/.+?\#key\#$", MessageTemplate = "URL must be valid and end with #key# pattern.")]
        [XmlElement("JIRAIssueUrlTemplate")]
        [HelpString(HelpResourceKey = "JiraIssueUrlTemplate")]
        public string UrlTemplate
        {
            get { return urlTemplate; }
            set
            {
                if (urlTemplate != value)
                {
                    urlTemplate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlElement("JIRAIssueUrlTitle")]
        public string UrlTitle
        {
            get { return urlTitle; }
            set
            {
                if (urlTitle != value)
                {
                    urlTitle = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [NonEmptyStringValidator]
        [XmlElement("SourceFieldValue")]
        [HelpString(HelpResourceKey = "JiraSourceFieldValue")]
        public string SourceName
        {
            get { return sourceName; }
            set
            {
                if (sourceName != value)
                {
                    sourceName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlElement("WorkitemLinkFieldId")]
        [HelpString(HelpResourceKey = "JiraWorkitemLinkFieldId")]
        public string LinkField
        {
            get { return linkField; }
            set
            {
                if (linkField != value)
                {
                    linkField = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [SelfValidation]
        public void CheckProjectMappings(ValidationResults results)
        {
            var validator = ValidationFactory.CreateValidator<JiraProjectMapping>();

            foreach (var mapping in ProjectMappings)
            {
                var mappingValidationResults = validator.Validate(mapping);

                if (!mappingValidationResults.IsValid)
                {
                    results.AddAllResults(mappingValidationResults);
                }
            }
        }

        [SelfValidation]
        public void CheckPriorityMappings(ValidationResults results)
        {
            var validator = ValidationFactory.CreateValidator<JiraPriorityMapping>();

            foreach (var mapping in PriorityMappings)
            {
                var mappingValidationResults = validator.Validate(mapping);

                if (!mappingValidationResults.IsValid)
                {
                    results.AddAllResults(mappingValidationResults);
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (JiraServiceEntity)obj;

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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}