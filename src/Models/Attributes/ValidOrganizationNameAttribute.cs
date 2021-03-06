namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidOrganizationNameAttribute : ValidStringTypePropertyAttribute
    {
        public const int MinLength = 3;
        public const int MaxLength = 64;

        public const string ValidRegex = "^[А-яёA-z0-9- ()\"]*$";

        public ValidOrganizationNameAttribute()
            : base(ValidRegex, MinLength, MaxLength)
        { }
    }
}