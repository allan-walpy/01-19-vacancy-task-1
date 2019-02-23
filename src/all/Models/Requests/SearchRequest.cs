using System.ComponentModel;

using Walpy.VacancyApp.Server.All.Models.Attributes;

namespace Walpy.VacancyApp.Server.All.Models.Requests
{
    /// <summary>
    /// Информация о поисковом запросе
    /// </summary>
    [AnyNotNull(nameof(Salary), nameof(Organization), nameof(KeyWords))]
    public class SearchRequest
    {
        /// <summary>
        /// Информация о фильтре по зарплате
        /// </summary>
        [DisplayName("Фильтр по зарплате")]
        public SalaryFilterModel Salary { get; set; }

        /// <summary>
        /// Информация о фильтре по нанимателю
        /// </summary>
        [DisplayName("Фильтр по работодателю")]
        public OrganizationFilterModel Organization { get; set; }

        /// <summary>
        /// Информация о фильтре по ключевым словам
        /// </summary>
        [DisplayName("Фильтр по ключевым словам")]
        public KeyWordsFilterModel KeyWords { get; set; }
    }
}