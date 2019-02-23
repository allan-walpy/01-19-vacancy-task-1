using System;
using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.All.Models.Attributes
{
    public class RangeLengthAttribute : StringLengthAttribute
    {
        public RangeLengthAttribute(int min, int max)
            : base(max)
        {
            MinimumLength = min;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var stringValue = value as string;
            if (stringValue == null)
            {
                return ValidationResult.Success;
            }

            var success = base.IsValid(value);
            if (success)
            {
                return ValidationResult.Success;
            }

            var config = Common.GetValidationConfiguration<RangeLengthAttribute>(context, this);
            var message = config["failed"];
            return new ValidationResult(
                String.Format(
                    message,
                    MinimumLength,
                    MaximumLength,
                    context.DisplayName
                ));
        }
    }
}