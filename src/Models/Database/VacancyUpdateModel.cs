using System.Collections.Generic;

using App.Server.Models.Attributes;

namespace App.Server.Models.Database
{
    /// <summary>
    /// Запрос на обновление данных вакансии
    /// </summary>
    public class VacancyUpdateModel
    {
        /// <summary>
        /// Обновление названия должности
        /// </summary>
        [ValidUpdateField(typeof(ValidVacancyTitleAttribute))]
        public UpdateCommandModel<string> Title { get; set; }

        /// <summary>
        /// Обновление описания работы
        /// </summary>
        [ValidUpdateField(typeof(ValidVacancyDescriptionAttribute))]
        public UpdateCommandModel<string> Description { get; set; }

        /// <summary>
        /// Обновление доступных типов занятости
        /// </summary>
        [ValidUpdateField(typeof(ValidEmploymentTypeListAttribute))]
        public UpdateCommandModel<List<string>> EmploymentType { get; set; }

        /// <summary>
        /// Обновление данных о зарплате
        /// </summary>
        [ValidUpdateField(typeof(ValidSalaryAttribute))]
        public UpdateCommandModel<decimal?> Salary { get; set; }

        /// <summary>
        /// Обновление информации о контактном лице
        /// </summary>
        public UpdateCommandModel<Person> ContactPerson { get; set; }

        /// <summary>
        /// Обновление контакного телефона
        /// </summary>
        [ValidUpdateField(typeof(ValidPhoneNumberAttribute))]
        public UpdateCommandModel<string> ContactPhone { get; set; }
    }
}