using System.Linq;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class AnyNotNullAttribute : NullFilterAttribute
    {
        public AnyNotNullAttribute(params string[] propertiesName)
            : base(propertiesName)
        { }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var hasAnyProperty = GetPropertyIsNotNullList(value)
                .Any((hasProperty) => hasProperty);

            return hasAnyProperty;
        }
    }
}