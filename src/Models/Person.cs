using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Walpy.VacancyApp.Server.Models.Attributes;

namespace Walpy.VacancyApp.Server.Models
{
    /// <summary>
    /// Представляет собой полное или частичное имя человека
    /// </summary>
    public class Person : IEquatable<Person>
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
            return Equals(person);
        }

        public bool Equals(Person person)
            => person == null
                ? false
                : Name == person.Name
                    && Surname == person.Surname
                    && MiddleName == person.MiddleName;

        public override int GetHashCode()
            => ToString().GetHashCode();

        public override string ToString()
            => $"{Name} {Surname} {MiddleName}";
    }
}