using Walpy.VacancyApp.Server.Core.Types;

namespace Walpy.VacancyApp.Server.Core.Attributes
{
    public class ValidEmploymentTypeListAttribute : ValidEnumListAttribute
    {
        public ValidEmploymentTypeListAttribute()
            : base(typeof(EmploymentType))
        { }
    }
}