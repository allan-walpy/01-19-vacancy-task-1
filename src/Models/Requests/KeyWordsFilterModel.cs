using System.ComponentModel.DataAnnotations;

using Walpy.VacancyApp.Server.Models.Attributes;
using Walpy.VacancyApp.Server.Models.Services;

namespace Walpy.VacancyApp.Server.Models.Requests
{
    /// <summary>
    /// Настройки фильтра поиска по нанимателю
    /// </summary>
    [AnyNotNull(nameof(SearchString))]
    public class KeyWordsFilterModel
    {
        /// <summary>
        /// Строка поискового запроса
        /// </summary>
        /// <example>junior developer младший разработчик</example>
        [Required]
        public string SearchString { get; set; }

        /// <summary>
        /// Вид соответсвия
        /// </summary>
        /// <example>anyWord</example>
        [Required]
        [ValidEnum(typeof(KeyWordsFilter.SearchStringMatch))]
        public string Match { get; set; }

        /// <summary>
        /// Поля по которым проводится поиск
        /// </summary>
        /// <example>title</example>
        [Required]
        [ValidEnum(typeof(KeyWordsFilter.SearchStringScope))]
        public string Scope { get; set; }
    }
}