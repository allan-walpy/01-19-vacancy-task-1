using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidStringTypePropertyAttribute : RangeLengthAttribute
    {
        protected List<string> Regexes { get; }

        public ValidStringTypePropertyAttribute(string[] validRegexes, int minLength, int maxLength)
            : base(minLength, maxLength)
        {
            Regexes = validRegexes?.ToList();
            if (Regexes == null || Regexes.Count == 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(validRegexes),
                    validRegexes,
                    "Expected at least one regex pattern. If regex not required use RangeLengthAttribute instead");
            }
        }

        public ValidStringTypePropertyAttribute(string validRegex, int minLength, int maxLength)
            : this(new[] { validRegex }, minLength, maxLength)
        { }

        protected static bool IsValidByRegex(string pattern, string value)
        {
            var regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var name = value as string;

            var baseResult = base.GetValidationResult(name, context);
            if (baseResult.IsFailed())
            {
                return baseResult;
            }

            var config = Common.GetValidationConfiguration<ValidStringTypePropertyAttribute>(context, this);
            var thisSuccess = name == null ? false : Regexes.Any(name.IsValidByRegexPattern);
            var thisResult = thisSuccess
                ? ValidationResult.Success :
                new ValidationResult(
                    String.Format(
                        config["failed"],
                        String.Join(", ", Regexes.ConvertAll((regex) => $"'{regex}'"))
                ));

            return thisResult;
        }
    }
}