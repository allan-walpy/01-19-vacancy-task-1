using System;
using System.Collections;

namespace App.Server.Models.Attributes
{
    public class ValidEnumListAttribute : ValidEnumAttribute
    {
        public ValidEnumListAttribute(Type enumType)
            : base(enumType)
        { }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var enumerableValue = value as IEnumerable;
            if (enumerableValue == null)
            {
                return false;
            }

            var success = true;
            foreach (var item in enumerableValue)
            {
                success = success && base.IsValid(item);
            }
            return success;
        }
    }
}