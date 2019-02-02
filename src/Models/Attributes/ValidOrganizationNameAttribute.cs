namespace App.Server.Models.Attributes
{
    public class ValidOrganizationNameAttribute : ValidStringTypePropertyAttribute
    {
        public const int MinLength = 0;
        public const int MaxLength = 64;

        public const string ValidRegex = "^[А-яA-z0-9- ()\"]*$";

        public ValidOrganizationNameAttribute()
            : base(ValidRegex, MinLength, MaxLength)
        { }
    }
}