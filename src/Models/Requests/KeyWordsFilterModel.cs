using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Walpy.VacancyApp.Server.Models.Requests
{
    /// <summary>
    /// Настройки фильтра поиска по нанимателю
    /// </summary>
    [DisplayName("Фильтр по ключевым словам")]
    public class KeyWordsFilterModel
    {
        /// <summary>
        /// Строка поискового запроса
        /// </summary>
        /// <example>junior developer младший разработчик</example>
        [Required]
        [DisplayName("Поисковая строка")]
        public string SearchString { get; set; }

        /// <summary>
        /// Тип совпадения
        /// </summary>
        /// <example>anyWord</example>
        [Required]
        [DisplayName("Тип совпадения")]
        public KeyWordSearchMatch Match { get; set; }

        /// <summary>
        /// Место поиска
        /// </summary>
        /// <example>title</example>
        [Required]
        [DisplayName("Место поиска")]
        public KeyWordSearchScope Scope { get; set; }
    }
}