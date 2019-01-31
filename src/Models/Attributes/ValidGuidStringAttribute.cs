using System;
using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Attributes
{
    public class ValidGuidStringAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var stringValue = value as string;
            if (stringValue == null)
            {
                return false;
            }

            Guid guidParsed = Guid.Empty;
            bool success = System.Guid.TryParse(stringValue, out guidParsed);
            return success & (guidParsed != Guid.Empty);
        }
    }
}