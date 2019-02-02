using System;
using System.ComponentModel.DataAnnotations;

using App.Server.Models.Database;

namespace App.Server.Models.Attributes
{
    public class ValidUpdateFieldAttribute : ValidationAttribute
    {
        public Type Validation { get; }

        public ValidUpdateFieldAttribute(Type validation)
        {
            Validation = validation;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            //? I tried, but...
            //TODO:FIXME:;
            var updateString = value as UpdateCommandModel<string>;
            var updateNullableDecimal = value as UpdateCommandModel<decimal?>;

            return Validate(updateString) || Validate(updateNullableDecimal);
        }

        private bool Validate<T>(UpdateCommandModel<T> update)
        {
            if (update == null)
            {
                return false;
            }

            if (!update.IsModified)
            {
                return true;
            }

            var validation = Validation
                .GetConstructor(new Type[] { })
                .Invoke(new object[] { })
                as ValidationAttribute;
            return validation?.IsValid(update.Value) ?? false;
        }
    }
}