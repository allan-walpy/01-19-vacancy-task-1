using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public abstract class NullFilterAttribute : ValidationAttribute
    {
        protected List<string> PropertiesName { get; }

        /// <summary>
        /// Creates base of Null Filter attribute
        /// </summary>
        /// <param name="otherPropertiesName">properties names filter applied to - if no specified, then all properties included</param>
        protected NullFilterAttribute(params string[] otherPropertiesName)
        {
            var propertiesNames = new List<string>();

            if (otherPropertiesName.Length > 0)
            {
                propertiesNames.AddRange(otherPropertiesName);
            }

            PropertiesName = propertiesNames;
        }

        protected List<bool> GetPropertyIsNullList(object value)
            => Common.GetPropertiesInfo(value, PropertiesName)
                .ConvertAll((propertyInfo) => IsExists(propertyInfo) && IsNull(propertyInfo, value));

        protected List<bool> GetPropertyIsNotNullList(object value)
            => GetPropertyIsNullList(value).ConvertAll((b) => !b);

        protected bool IsExists(PropertyInfo info)
            => info == null;

        protected bool IsNull(PropertyInfo info, object value)
            => info.GetValue(value) == null;

        protected override abstract ValidationResult IsValid(object value, ValidationContext context);
    }
}