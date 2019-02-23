using System;
using System.ComponentModel.DataAnnotations;

using Walpy.VacancyApp.Server.Core.Database;

namespace Walpy.VacancyApp.Server.Core.Attributes
{
    public class ValidUpdateFieldAttribute : ValidationAttribute
    {
        public Type Validation { get; }

        public ValidUpdateFieldAttribute(Type validation)
        {
            Validation = validation;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var updateString = value as UpdateCommandModel<string>;
            if (updateString != null)
            {
                return Validate(updateString, context);
            }

            var updateNullableDecimal = value as UpdateCommandModel<decimal?>;
            return Validate(updateNullableDecimal, context);
        }

        private ValidationResult Validate<T>(UpdateCommandModel<T> update, ValidationContext context)
        {
            if (update == null || !update.IsModified)
            {
                return ValidationResult.Success;
            }

            var validation = Validation
                .GetConstructor(new Type[] { })
                .Invoke(new object[] { })
                as ValidationAttribute;
            return validation?.GetValidationResult(update.Value, context);
        }
    }
}