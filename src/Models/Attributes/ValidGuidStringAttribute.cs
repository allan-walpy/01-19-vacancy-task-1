using System;
using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.Models.Attributes
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

            Guid guidParsed;
            var success = System.Guid.TryParse(stringValue, out guidParsed);
            return success;
        }
    }
}