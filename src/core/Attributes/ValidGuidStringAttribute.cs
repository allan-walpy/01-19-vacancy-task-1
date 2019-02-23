using System;
using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.Core.Attributes
{
    public class ValidGuidStringAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var config = Common.GetValidationConfiguration<ValidGuidStringAttribute>(context, this);
            if (value == null)
            {
                return new ValidationResult(config["failed:null"]);
            }

            var stringValue = value as string;
            Guid guidParsed;
            var success = System.Guid.TryParse(stringValue, out guidParsed);
            if (success)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(config["failed:format"]);
        }
    }
}