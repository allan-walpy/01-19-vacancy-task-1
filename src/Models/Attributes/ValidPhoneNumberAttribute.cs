
using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Attributes
{
    public class ValidPhoneNumberAttribute : ValidationAttribute
    {
        private const string ValidRegexMobile =
            @"^\d{1} \(\d{3}) \d{3}-\d{2}-\d{2}$";

        private const string ValidRegexHomePhone =
            @"^\d{1} \(\d{4}) \d{2}-\d{2}-\d{2}$";

        public override bool IsValid(object value)
        {
            var stringValue = value as string;
            if (stringValue == null)
            {
                return false;
            }

            return stringValue.IsValidByRegexPattern(ValidRegexMobile)
                || stringValue.IsValidByRegexPattern(ValidRegexHomePhone);
        }
    }
}