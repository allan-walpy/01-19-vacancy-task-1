using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Walpy.VacancyApp.Server.Models.Attributes;

namespace Walpy.VacancyApp.Server.Models
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

        public override bool Equals(object obj)
        {
            var person = obj as Person;

            if (object.Equals(obj, null)
                || object.Equals(person, null))
            {
                return false;
            }

            return Name == person.Name
                && Surname == person.Surname
                && MiddleName == person.MiddleName;
        }

        public override int GetHashCode()
            => ToString().GetHashCode();

        public override string ToString()
            => $"{Name} {Surname} {MiddleName}";
    }
}