using App.Server.Models.Database;

namespace App.Server.Models.Services
{
    public class SalaryFilter : SearchFilterBase<SalaryFilterOptions>
    {
        public SalaryFilter(SalaryFilterOptions options)
            : base(options)
        { }

        protected bool CheckMax(decimal salary)
            => Options.Max == null ? true : salary <= Options.Max;

        protected bool CheckMin(decimal salary)
            => Options.Min == null ? true : salary >= Options.Min;

        protected override bool Check(VacancyModel vacancy)
        {
            if (vacancy.Salary == null)
            {
                return false;
            }

            var salary = vacancy.Salary ?? 0;
            var isValid = CheckMin(salary) && CheckMax(salary);
            return isValid;
        }
    }
}