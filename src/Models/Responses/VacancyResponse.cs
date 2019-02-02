using System.Collections.Generic;

namespace App.Server.Models.Responses
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
        public string Id { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        /// <example>Junior .Net Developer</example>
        public string Title { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        /// <example>15000</example>
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
        public string Description { get; set; }

        /// <summary>
        /// Информация об компании-работодателе
        /// </summary>
        public OrganizationResponse Organization { get; set; }

        /// <summary>
        /// Тип занятости
        /// </summary>
        /// <example>[ "FullTime", "FixedScheldure" ]</example>
        public ICollection<string> EmploymentType { get; set; }

        /// <summary>
        /// Имя контактного лица
        /// </summary>
        public Person ContactPerson { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        /// <example>8 (4843) 22-33-42</example>
        public string ContactPhone { get; set; }

        /// <summary>
        /// Последнее обновление вакансии ввиде unix timestamp mllieconds
        /// </summary>
        /// <example>1549110630613</example>
        public long LastUpdated { get; set; }

        /// <summary>
        /// Дата создания вакансии ввиде unix timestamp milliseconds
        /// </summary>
        /// <example>1548110621245</example>
        public long CreatedAt { get; set; }
    }
}