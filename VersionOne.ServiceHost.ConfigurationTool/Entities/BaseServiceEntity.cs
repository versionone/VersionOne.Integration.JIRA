using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    /// <summary>
    /// Base class for all Service configuration entities.
    /// </summary>
    public abstract class BaseServiceEntity : BaseEntity
    {
        private TimerEntity timer;

        [XmlIgnore]
        public TimerEntity Timer
        {
            get { return timer; }
            set
            {
                timer = value;
                NotifyPropertyChanged();
            }
        }

        [XmlIgnore]
        public bool HasTimer
        {
            get { return Timer != null; }
        }

        [XmlAttribute("class")]
        public virtual string ClassName
        {
            get
            {
                var serviceMap = ServicesMap.GetByEntityType(GetType());
                return serviceMap != null ? serviceMap.FullTypeNameAndAssembly : string.Empty;
            }
            set { }
        }

        [XmlAttribute("disabled")]
        public virtual int DisabledNumeric
        {
            get { return Convert.ToInt32(Disabled); }
            set { Disabled = Convert.ToBoolean(value); }
        }

        protected void CreateTimer(int timeoutMinutes)
        {
            var thisService = ServicesMap.GetByEntityType(GetType());

            Timer = new TimerEntity
            {
                PublishClass = thisService.PublishClass + ", " + thisService.Assembly,
                Disabled = false,
                TimeoutMinutes = timeoutMinutes
            };
        }
    }
}