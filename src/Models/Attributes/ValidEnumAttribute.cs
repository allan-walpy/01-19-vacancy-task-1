using System;
using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Attributes
{
    public class ValidEnumAttribute : ValidationAttribute
    {
        protected Type EnumType { get; }

        public ValidEnumAttribute(Type enumType)
        {
            EnumType = enumType;
        }

        public override bool IsValid(object value)
        {
            var stringValue = value as string;
            if (stringValue == null)
            {
                return true;
            }

            object result = null;
            var success = Enum.TryParse(EnumType, stringValue, ignoreCase: true, result: out result);
            return success;
        }
    }
}