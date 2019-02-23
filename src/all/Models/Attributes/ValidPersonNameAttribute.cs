namespace Walpy.VacancyApp.Server.All.Models.Attributes
{
    public class ValidPersonNameAttribute : ValidStringTypePropertyAttribute
    {
        public const string ValidRegex = "^[А-яёA-z-]*$";
        public const int MaxLength = 20;
        public const int MinLength = 3;

        public ValidPersonNameAttribute()
            : base(ValidRegex, MinLength, MaxLength)
        { }
    }
}