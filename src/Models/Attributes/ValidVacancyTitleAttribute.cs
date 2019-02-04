namespace App.Server.Models.Attributes
{
    public class ValidVacancyTitleAttribute : ValidStringTypePropertyAttribute
    {
        public const string ValidRegex = "^[А-яёA-z0-9-.;:, ()/#]*$";
        public const int MinLength = 3;
        public const int MaxLength = 64;

        public ValidVacancyTitleAttribute()
            : base(ValidRegex, MinLength, MaxLength)
        { }
    }
}