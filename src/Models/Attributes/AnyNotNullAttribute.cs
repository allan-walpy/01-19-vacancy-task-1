using System.Linq;

namespace App.Server.Models.Attributes
{
    public class AnyNotNullAttribute : NullFilterAttribute
    {
        public AnyNotNullAttribute(params string[] propertiesName)
            : base(propertiesName)
        { }

        public override bool IsValid(object value)
        {
            var hasAnyProperty = GetPropertyIsNotNullList(value)
                .Any((hasProperty) => hasProperty == true);

            return hasAnyProperty;
        }
    }
}