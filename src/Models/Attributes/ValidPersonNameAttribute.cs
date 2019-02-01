namespace App.Server.Models.Attributes
{
    //? applied on Name, Surname, ThirdName - string values;
    public class ValidPersonNameAttribute : ValidStringTypePropertyAttribute
    {
        public const string ValidRegex = "^[А-я-]*$";
        public const int MaxLength = 20;
        public const int MinLength = 0;

        public ValidPersonNameAttribute()
            : base(ValidRegex, MinLength, MaxLength)
        { }
    }
}