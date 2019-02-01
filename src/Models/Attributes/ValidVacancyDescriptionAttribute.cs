namespace App.Server.Models.Attributes
{
    public class ValidVacancyDescriptionAttribute : RangeLengthAttribute
    {
        public const int MinLength = 0;
        public const int MaxLength = 4096;

        public ValidVacancyDescriptionAttribute()
            : base(MinLength, MaxLength)
        { }
    }
}