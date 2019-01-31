using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Attributes
{
    //? applied on Name, Surname, ThirdName - string values;
    public class ValidPersonNameAttribute : ValidationAttribute
    {
        private const string ValidRegex = @"[А-я-]*$";

        private static bool IsValidByRegex(string pattern, string value)
        {
            var regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        public override bool IsValid(object value)
        {
            var name = value as string;
            if (name == null)
            {
                //? if one of names not specified;
                return value is string;
            }

            return name.IsValidByRegexPattern(ValidRegex);
        }
    }
}