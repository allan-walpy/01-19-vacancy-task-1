using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using App.Server.Models.Attributes;

namespace App.Server.Models
{
    /// <summary>
    /// Представляет собой полное или частичное имя человека
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        /// <example>Владимир</example>
        [Required]
        [ValidPersonName]
        [DisplayName("Имя")]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        /// <example>Милов</example>
        [ValidPersonName]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        /// <example>Станиславович</example>
        [ValidPersonName]
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }
    }
}