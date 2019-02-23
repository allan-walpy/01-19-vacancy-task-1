using System;
using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidEnumAttribute : ValidationAttribute
    {
        protected Type EnumType { get; }

        public ValidEnumAttribute(Type enumType)
        {
            EnumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            object dummy;
            var stringValue = value as string;
            var success = Enum.TryParse(EnumType, stringValue, ignoreCase: true, result: out dummy);
            if (success)
            {
                return ValidationResult.Success;
            }

            var enumNames = EnumType.GetEnumNames();
            var config = Common.GetValidationConfiguration<ValidEnumAttribute>(context, this);
            return new ValidationResult(
                String.Format(
                    config["failed"],
                    String.Join(
                        ", ",
                        enumNames)));
        }
    }
}