using System;
using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidSalaryAttribute : RangeAttribute
    {
        public const double Max = 1_000_000_000_000;
        public const double Min = 0;

        public ValidSalaryAttribute()
            : base(Min, Max)
        { }

        public ValidationResult ValidateValue(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var result = base.IsValid(value, context);
            if (result.IsSuccess())
            {
                return result;
            }

            var config = Common.GetValidationConfiguration<ValidSalaryAttribute>(context, this);
            return new ValidationResult(
                String.Format(config["failed"], Minimum, Maximum)
            );
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
            => ValidateValue(value, context);
    }
}