namespace Walpy.VacancyApp.Server.Models.Attributes
{
    public class ValidEmploymentTypeListAttribute : ValidEnumListAttribute
    {
        public ValidEmploymentTypeListAttribute()
            : base(typeof(EmploymentType))
        { }
    }
}