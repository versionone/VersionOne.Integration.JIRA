using System;
using System.Collections.Generic;
using VersionOne.ServiceHost.ConfigurationTool.DL;
using VersionOne.ServiceHost.ConfigurationTool.Entities;
using VersionOne.ServiceHost.ConfigurationTool.BZ;

namespace VersionOne.ServiceHost.ConfigurationTool.UI.Interfaces
{
    public interface IJiraPageView : IPageView<JiraServiceEntity>
    {
        event EventHandler ValidationRequested;
        void SetValidationResult(bool validationSuccessful);
        IEnumerable<string> AvailableSources { get; set; }
        IList<ProjectWrapper> ProjectWrapperList { get; set; }
        IList<ListValue> VersionOnePriorities { get; set; }
        IList<ListValue> JiraPriorities { get; set; }
        void SetGeneralTabValidity(bool isValid);
        void SetMappingTabValidity(bool isValid);
        void UpdateJiraPriorities(IList<ListValue> jiraPriorities);
    }
}