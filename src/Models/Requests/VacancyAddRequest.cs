using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using App.Server.Models.Attributes;

namespace App.Server.Models.Requests
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
        /// <example>
        /// Обязанности:
        ///  - разработка ПО;
        /// Требования:
        ///  - знания C#;
        ///  - понимание основных принципов ООП;
        ///  - опыт работы с ASP.NET Core/MVC/WebAPI;
        ///  - опыт работы с Entity Framework Core;
        ///  - опыт работы с git;
        ///  - умение разбираться с технической англоязычной документацией;
        ///  - умение работать в команде;
        ///  - умение писать код, понятный другим разработчикам;
        /// </example>
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
        /// <example>[ "FullTime", "FixedScheldure" ]</example>
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