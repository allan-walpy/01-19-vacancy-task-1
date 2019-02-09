using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Walpy.VacancyApp.Server.Models.Attributes;

namespace Walpy.VacancyApp.Server.Models.Requests
{
    /// <summary>
    /// Запрос на добавление вакансии
    /// </summary>
    public class VacancyAddRequest
    {
        /// <summary>
        /// Название должности
        /// </summary>
        /// <example>Junior .Net Developer</example>
        [Required]
        [ValidVacancyTitle]
        public string Title { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        /// <example>15000</example>
        [ValidSalary]
        public decimal? Salary { get; set; }

        /// <summary>
        /// Описание работы
        /// </summary>
        /// <example>## Обязанности:\n\n  - разработка ПО;\n\n## Требования:\n\n  - знания C#;\n  - понимание основных принципов ООП;\n  - опыт работы с ASP.NET Core/MVC/WebAPI;\n  - опыт работы с Entity Framework Core;\n  - опыт работы с git;\n  - умение разбираться с технической англоязычной документацией;\n  - умение работать в команде\n  - умение писать код, понятный другим разработчикам;</example>
        [Required]
        [ValidVacancyDescription]
        public string Description { get; set; }

        /// <summary>
        /// Название компании-работодателя
        /// </summary>
        [Required]
        [ValidOrganizationName]
        public string Organization { get; set; }

        /// <summary>
        /// Тип занятости
        /// </summary>
        /// <example>[ ]</example>
        [Required]
        [ValidEnumList(typeof(EmploymentType))]
        public List<string> EmploymentType { get; set; }

        /// <summary>
        /// Имя контактного лица
        /// </summary>
        public Person ContactPerson { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        /// <example>8 (4843) 22-33-42</example>
        [ValidPhoneNumber]
        public string ContactPhone { get; set; }
    }
}