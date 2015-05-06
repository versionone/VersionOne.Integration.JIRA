using System;
using VersionOne.ServiceHost.ConfigurationTool.BZ;
using VersionOne.ServiceHost.ConfigurationTool.Entities;
using VersionOne.ServiceHost.ConfigurationTool.UI.Interfaces;

namespace VersionOne.ServiceHost.ConfigurationTool.UI.Controllers
{
    public class JiraController : BasePageController<JiraServiceEntity, IJiraPageView>
    {
        public JiraController(JiraServiceEntity model, IFacade facade) : base(model, facade) { }

        public override void PrepareView()
        {
            View.ValidationRequested += View_ValidationRequested;
            View.ControlValidationTriggered += View_ControlValidationTriggered;

            try
            {
                View.AvailableSources = Facade.GetSourceList();
                View.ProjectWrapperList = Facade.GetProjectWrapperList();
                View.VersionOnePriorities = Facade.GetVersionOnePriorities();
                base.PrepareView();
            }
            catch (BusinessException ex)
            {
                View.DisplayError(ex.Message);
            }
        }

        private void View_ControlValidationTriggered(object sender, EventArgs e)
        {
            var results = Facade.ValidateEntity(Model);
            var generalTabValid = true;
            var mappingTabValid = true;

            foreach (var result in results)
            {
                var targetType = result.Target.GetType();

                if (targetType == typeof(JiraServiceEntity) || targetType == typeof(JiraFilter))
                {
                    generalTabValid = false;
                }

                if (targetType == typeof(JiraProjectMapping) || targetType == typeof(JiraPriorityMapping))
                {
                    mappingTabValid = false;
                }
            }

            View.SetGeneralTabValidity(generalTabValid);
            View.SetMappingTabValidity(mappingTabValid);
        }

        private void View_ValidationRequested(object sender, EventArgs e)
        {
            try
            {
                var result = Facade.ValidateConnection(Model);
                View.SetValidationResult(result);

                if (result)
                {
                    var jiraPriorities = Facade.GetJiraPriorities(Model.Url, Model.UserName, Model.Password);
                    View.UpdateJiraPriorities(jiraPriorities);
                }
            }
            catch (AssemblyLoadException ex)
            {
                FormController.FailApplication(ex.Message);
            }
        }
    }
}