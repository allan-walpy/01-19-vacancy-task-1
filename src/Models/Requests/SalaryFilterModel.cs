using System.ComponentModel;

using Walpy.VacancyApp.Server.Models.Attributes;

namespace Walpy.VacancyApp.Server.Models.Requests
{
    /// <summary>
    /// Настройки фильтра поиска по зарплате
    /// </summary>
    [ValidSalaryFilter]
    [AnyNotNull(nameof(Max), nameof(Min))]
    [DisplayName("Фильтр по зарплате")]
    public class SalaryFilterModel
    {
        /// <summary>
        /// Зарплата до
        /// </summary>
        /// <example>60000</example>
        [ValidSalary]
        [DisplayName("Макимальная зарплата")]
        public decimal? Max { get; set; }

        /// <summary>
        /// Зарплата от
        /// </summary>
        /// <example>15000</example>
        [ValidSalary]
        [DisplayName("Минимальная зарплата")]
        public decimal? Min { get; set; }
    }
}