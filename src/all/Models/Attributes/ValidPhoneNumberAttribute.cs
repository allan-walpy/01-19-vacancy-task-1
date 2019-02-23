namespace Walpy.VacancyApp.Server.All.Models.Attributes
{
    public class ValidPhoneNumberAttribute : ValidStringTypePropertyAttribute
    {
        private const string ValidRegexMobile = @"^\d{1} \(\d{3}\) \d{3}-\d{2}-\d{2}$";
        private const string ValidRegexHomePhone = @"^\d{1} \(\d{4}\) \d{2}-\d{2}-\d{2}$";
        public const int MaxLength = 20;
        public const int MinLength = 11;

        public ValidPhoneNumberAttribute()
            : base(
                validRegexes: new[] { ValidRegexMobile, ValidRegexHomePhone },
                maxLength: MaxLength,
                minLength: MinLength)
        { }
    }
}