using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.All.Models.Attributes
{
    public class ValidGuidStringOrNullAttribute : ValidGuidStringAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            return base.IsValid(value, context);
        }
    }
}