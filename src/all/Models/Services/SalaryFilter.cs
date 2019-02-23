using System;

using Walpy.VacancyApp.Server.All.Models.Database;

namespace Walpy.VacancyApp.Server.All.Models.Services
{
    public class SalaryFilter : SearchFilterBase<SalaryFilterOptions>
    {
        public SalaryFilter(SalaryFilterOptions options)
            : base(options)
        {
            CheckLimits();
        }

        protected void CheckLimits()
        {
            if (Options.Max == null || Options.Min == null)
            {
                return;
            }

            var max = Math.Max(Options.Max ?? 0, Options.Min ?? 0);
            var min = Math.Min(Options.Max ?? 0, Options.Min ?? 0);
            Options.Min = min;
            Options.Max = max;
        }

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