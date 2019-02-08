using System;
using System.Collections.Generic;
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

        public override bool IsValid(object value)
        {
            var name = value as string;
            if (name == null)
            {
                //? validation on non string and null strings values is always true;
                //? use Required on string values to make them not nullabale;
                return true;
            }

            return base.IsValid(name)
                && Regexes.Any(name.IsValidByRegexPattern);
        }
    }
}