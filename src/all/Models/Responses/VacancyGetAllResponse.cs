using System.Collections.Generic;

namespace Walpy.VacancyApp.Server.All.Models.Responses
{
    /// <summary>
    /// Информация обо всех вакансиях
    /// </summary>
    public class VacancyGetAllResponse
    {
        /// <summary>
        /// Лист вакансий отсортированный по убыванию <see cref="VacancyResponse.LastUpdated" />
        /// </summary>
        public List<VacancyResponse> List { get; set; }
    }
}