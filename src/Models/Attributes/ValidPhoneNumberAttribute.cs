namespace App.Server.Models.Attributes
{
    public class ValidPhoneNumberAttribute : ValidStringTypePropertyAttribute
    {
        private const string ValidRegexMobile = @"^\d{1} \(\d{3}\) \d{3}-\d{2}-\d{2}$";
        private const string ValidRegexHomePhone = @"^\d{1} \(\d{4}\) \d{2}-\d{2}-\d{2}$";
        public const int MaxLength = 11;
        public const int MinLength = 20;

        public ValidPhoneNumberAttribute()
            : base(
                validRegexes: new[] { ValidRegexMobile, ValidRegexHomePhone },
                maxLength: MaxLength,
                minLength: MinLength)
        { }
    }
}