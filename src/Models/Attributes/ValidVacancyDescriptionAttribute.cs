namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidVacancyDescriptionAttribute : RangeLengthAttribute
    {
        public const int MinLength = 3;
        public const int MaxLength = 4096;

        public ValidVacancyDescriptionAttribute()
            : base(MinLength, MaxLength)
        { }
    }
}