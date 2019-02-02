using System.ComponentModel.DataAnnotations;

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
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        /// <example>Милов</example>
        [ValidPersonName]
        public string Surname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        /// <example>Станиславович</example>
        [ValidPersonName]
        public string MiddleName { get; set; }
    }
}