using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidGuidStringOrNullAttribute : ValidGuidStringAttribute
    {
        public new ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            return base.GetValidationResult(value, context);
        }
    }
}