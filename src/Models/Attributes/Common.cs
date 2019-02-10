using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public static class Common
    {
        public const string ValidationMessagesConfigSection = "message:validation";
        public static IConfiguration GetConfiguration(ValidationContext context)
            => (IConfiguration)context.GetService(typeof(IConfiguration));

        public static IConfiguration GetValidationConfiguration(ValidationContext context)
            => GetConfiguration(context).GetSection(ValidationMessagesConfigSection);

        public static IConfiguration GetValidationConfiguration<T>(
            ValidationContext context,
            T instance)
            => GetValidationConfiguration(context).GetSection(typeof(T).Name);

        public static List<PropertyInfo> GetPropertiesInfo(object value, List<string> propertiesName = null)
        {
            var valueType = value.GetType();

            if (propertiesName == null || propertiesName.Count == 0)
            {
                return valueType.GetProperties().ToList();
            }

            return propertiesName.ConvertAll((name) => valueType.GetProperty(name));
        }

        public static string GetDisplayName(this MemberInfo memberInfo, string defaultValue = null)
        {
            var name = typeof(DisplayNameAttribute).Name;
            return memberInfo.CustomAttributes
                .FirstOrDefault((attribute) => attribute.AttributeType.Name == name)
                ?.ConstructorArguments?.First().Value as string
                ?? defaultValue;
        }

        public static bool IsSuccess(this ValidationResult result)
            => result == ValidationResult.Success;

        public static bool IsFailed(this ValidationResult result)
            => !result.IsSuccess();
    }
}