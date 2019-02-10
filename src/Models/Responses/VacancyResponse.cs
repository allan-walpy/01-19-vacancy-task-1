using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Walpy.VacancyApp.Server.Models.Attributes;

namespace Walpy.VacancyApp.Server.Models.Responses
{
    /// <summary>
    /// Информация о вакансии
    /// </summary>
    public class VacancyResponse
    {
        /// <summary>
        /// Guid вакансии
        /// </summary>
        /// <example>40213585-be3b-4ad6-a6f6-e5d1c2e5cb25</example>
        [DisplayName("Внутренний идентификатор")]
        public string Id { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        /// <example>Junior .Net Developer</example>
        [Required]
        [ValidVacancyTitle]
        [DisplayName("Наименование должности")]
        public string Title { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        /// <example>15000</example>
        [ValidSalary]
        [DisplayName("Зарплата")]
        public decimal? Salary { get; set; }

        /// <summary>
        /// Описание работы
        /// </summary>
        /// <example>
        /// ## Обязанности:\n  - разработка ПО;\n##Требования:\n  - знания C#;\n  - понимание основных принципов ООП;\n  - опыт работы с ASP.NET Core/MVC/WebAPI;\n  - опыт работы с Entity Framework Core;\n  - опыт работы с git;\n  - умение разбираться с технической англоязычной документацией;\n  - умение работать в команде;\n  - умение писать код, понятный другим разработчикам;
        /// </example>
        [Required]
        [ValidVacancyDescription]
        [DisplayName("Описание должности")]
        public string Description { get; set; }

        /// <summary>
        /// Информация об компании-работодателе
        /// </summary>
        [DisplayName("Работодатель")]
        public OrganizationResponse Organization { get; set; }

        /// <summary>
        /// Тип занятости
        /// </summary>
        /// <example>[ "FullTime", "FixedScheldure" ]</example>
        [ValidEnumList(typeof(EmploymentType))]
        [DisplayName("Тип занятости")]
        public ICollection<string> EmploymentType { get; set; }

        /// <summary>
        /// Имя контактного лица
        /// </summary>
        [DisplayName("Контактное лицо")]
        public Person ContactPerson { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        /// <example>8 (4843) 22-33-42</example>
        [ValidPhoneNumber]
        [DisplayName("Контактный телефон")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Последнее обновление вакансии ввиде unix timestamp mllieconds
        /// </summary>
        /// <example>1549110630613</example>
        [DisplayName("Последнее обновление")]
        public long LastUpdated { get; set; }

        /// <summary>
        /// Дата создания вакансии ввиде unix timestamp milliseconds
        /// </summary>
        /// <example>1548110621245</example>
        [DisplayName("Дата создания")]
        public long CreatedAt { get; set; }
    }
}