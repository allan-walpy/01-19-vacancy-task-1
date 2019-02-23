using System.ComponentModel;

namespace Walpy.VacancyApp.Server.Models.Requests
{
    /// <summary>
    /// Место поиска
    /// </summary>
    [DisplayName("Место поиска")]
    public enum KeyWordSearchScope
    {
        /// <summary>
        /// По названию должности
        /// </summary>
        [DisplayName("По названию должности")]
        Title,

        /// <summary>
        /// По описанию должности
        /// </summary>
        [DisplayName("По описанию должности")]
        Description,

        /// <summary>
        /// В обоих полях
        /// </summary>
        [DisplayName("В обоих полях")]
        Both
    }
}