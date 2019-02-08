using Walpy.VacancyApp.Server.Models.Attributes;

namespace Walpy.VacancyApp.Server.Models.Requests
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
        public SalaryFilterModel Salary { get; set; }

        /// <summary>
        /// Информация о фильтре по нанимателю
        /// </summary>
        public OrganizationFilterModel Organization { get; set; }

        /// <summary>
        /// Информация о фильтре по ключевым словам
        /// </summary>
        public KeyWordsFilterModel KeyWords { get; set; }
    }
}