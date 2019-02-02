using App.Server.Models.Attributes;

namespace App.Server.Models.Requests
{
    /// <summary>
    /// Настройки фильтра поиска по зарплате
    /// </summary>
    [AnyNotNull(nameof(Max), nameof(Min))]
    public class SalaryFilterModel
    {
        /// <summary>
        /// Зарплата до
        /// </summary>
        /// <example>60000</example>
        [ValidSalary]
        public decimal? Max { get; set; }

        /// <summary>
        /// Зарплата от
        /// </summary>
        /// <example>15000</example>
        [ValidSalary]
        public decimal? Min { get; set; }
    }
}