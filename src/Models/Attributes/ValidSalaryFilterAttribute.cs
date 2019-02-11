using System;
using System.ComponentModel.DataAnnotations;

using Walpy.VacancyApp.Server.Models.Requests;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidSalaryFilterAttribute : ValidationAttribute
    {
        protected ValidSalaryAttribute ValidSalary { get; }

        public ValidSalaryFilterAttribute()
        {
            ValidSalary = new ValidSalaryAttribute();
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var filter = value as SalaryFilterModel;

            var config = Common.GetValidationConfiguration<ValidSalaryFilterAttribute>(context, this);
            if (filter == null)
            {
                return new ValidationResult(config["failed:invalidType"]);
            }

            var min = filter.Min;
            var resultMin = ValidSalary.ValidateValue(min, context);
            if (resultMin != ValidationResult.Success)
            {
                return resultMin;
            }

            var max = filter.Max;
            var resultMax = ValidSalary.ValidateValue(max, context);
            if (resultMax != ValidationResult.Success)
            {
                return resultMin;
            }

            if (max == null || min == null || min <= max)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                String.Format(config["failed:invalidRanges"], min, max)
            );
        }
    }
}