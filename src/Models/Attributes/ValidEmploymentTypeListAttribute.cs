namespace App.Server.Models.Attributes
{
    public class ValidEmploymentTypeListAttribute : ValidEnumListAttribute
    {
        public ValidEmploymentTypeListAttribute()
            : base(typeof(EmploymentType))
        { }
    }
}