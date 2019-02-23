using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Walpy.VacancyApp.Server.All.Models.Attributes
{
    public class ValidEnumListAttribute : ValidEnumAttribute
    {
        public ValidEnumListAttribute(Type enumType)
            : base(enumType)
        { }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var enumerableValue = value as IEnumerable;
            var results = new List<ValidationResult>();
            foreach (var item in enumerableValue)
            {
                results.Add(base.IsValid(item, context));
            }

            var success = !results.Any(Common.IsFailed);
            if (success)
            {
                return ValidationResult.Success;
            }

            return results.First(Common.IsFailed);
        }
    }
}