namespace Walpy.VacancyApp.Server.All.Models.Attributes
{
    public class ValidEmploymentTypeListAttribute : ValidEnumListAttribute
    {
        public ValidEmploymentTypeListAttribute()
            : base(typeof(EmploymentType))
        { }
    }
}