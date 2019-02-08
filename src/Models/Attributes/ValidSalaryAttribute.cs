using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.Models.Attributes
{
    //? non negative salary;
    public class ValidSalaryAttribute : RangeAttribute
    {
        //? RangeAttribute uses double;
        public const double Max = 1_000_000_000;
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