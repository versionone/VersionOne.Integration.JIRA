using System.Xml.Serialization;

namespace VersionOne.ServiceHost.ConfigurationTool.Entities
{
    public class NullableInt : BaseEntity
    {
        public const string StringValueProperty = "StringValue";

        private int? numberValue;

        [XmlIgnore]
        public int? NumberValue
        {
            get { return numberValue; }
            set
            {
                if (numberValue != value)
                {
                    numberValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlText]
        public string StringValue
        {
            get { return NumberValue.HasValue ? NumberValue.ToString() : null; }
            set
            {
                int parsedValue;
                if (int.TryParse(value, out parsedValue))
                    NumberValue = parsedValue;
                else
                    NumberValue = null;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(NullableInt))
            {
                return false;
            }

            var other = (NullableInt)obj;
            return NumberValue == other.NumberValue ||
                (NumberValue.HasValue && other.NumberValue.HasValue && NumberValue.Value == other.NumberValue.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return StringValue;
        }
    }
}