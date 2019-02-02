using System.Collections.Generic;

namespace App.Server.Models.Responses
{
    /// <summary>
    /// Результаты поиска
    /// </summary>
    public class SearchResponse
    {
        /// <summary>
        /// Результат поискового запроса, упорядоченного по убывнию по полю <see cref="VacancyResponse.LastUpdated" />
        /// </summary>
        public List<VacancyResponse> Result;
    }
}