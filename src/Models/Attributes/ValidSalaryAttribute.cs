using System.ComponentModel.DataAnnotations;

namespace App.Server.Models.Attributes
{
    //? non negative salary;
    public class ValidSalaryAttribute : RangeAttribute
    {
        //? double uses at RangeAttribute;
        public const double Max = System.Double.MaxValue;
        public const double Min = 0;

        public ValidSalaryAttribute()
            : base(
                minimum: Min,
                maximum: Max
            )
        { }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return base.IsValid(value);
        }
    }
}