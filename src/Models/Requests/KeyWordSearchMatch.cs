using System.ComponentModel;

namespace Walpy.VacancyApp.Server.Models.Requests
{
    /// <summary>
    /// Тип совпадения
    /// </summary>
    [DisplayName("Тип совпадения")]
    public enum KeyWordSearchMatch
    {
        /// <summary>
        /// Любое из слов
        /// </summary>
        [DisplayName("Любое из слов")]
        AnyWord,

        /// <summary>
        /// Каждое из слов
        /// </summary>
        [DisplayName("Каждое из слов")]
        AllWords,

        /// <summary>
        /// Точное совпадение
        /// </summary>
        [DisplayName("Точное совпадение")]
        ExactMatch
    }
}