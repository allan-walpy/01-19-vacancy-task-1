using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class AnyNotNullAttribute : NullFilterAttribute
    {
        public AnyNotNullAttribute(params string[] propertiesName)
            : base(propertiesName)
        { }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var notNullProperties = GetPropertyIsNotNullList(value);
            if (notNullProperties.Any((item) => item))
            {
                return ValidationResult.Success;
            }

            var config = Common.GetValidationConfiguration<AnyNotNullAttribute>(context, this);
            var propertiesNames = Common.GetPropertiesInfo(value, PropertiesName)
                .ConvertAll((info) => Common.GetDisplayName(info, info.Name));
            return new ValidationResult(
                String.Format(
                    config["failed"],
                    String.Join(
                        ", ",
                        propertiesNames))
            );
        }
    }
}