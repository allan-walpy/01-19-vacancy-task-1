using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public abstract class NullFilterAttribute : ValidationAttribute
    {
        protected List<string> PropertiesName { get; }

        protected NullFilterAttribute(params string[] otherPropertiesName)
        {
            if (otherPropertiesName.Length == 0)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(otherPropertiesName),
                    actualValue: otherPropertiesName,
                    message: "At least one property must be specified");
            }

            var propertiesNames = new List<string>();
            propertiesNames.AddRange(otherPropertiesName);

            PropertiesName = propertiesNames;
        }

        protected List<PropertyInfo> GetPropertiesInfo(object value)
        {
            var valueType = value.GetType();
            return PropertiesName.ConvertAll((name) => valueType.GetProperty(name));
        }

        protected List<bool> GetPropertyIsNullList(object value)
            => GetPropertiesInfo(value)
                .ConvertAll((propertyInfo) => IsExists(propertyInfo) && IsNull(propertyInfo, value));

        protected List<bool> GetPropertyIsNotNullList(object value)
            => GetPropertyIsNullList(value).ConvertAll((b) => !b);

        protected bool IsExists(PropertyInfo info)
            => info == null;

        protected bool IsNull(PropertyInfo info, object value)
            => info.GetValue(value) == null;

        public override abstract bool IsValid(object value);
    }
}