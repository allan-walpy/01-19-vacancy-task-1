using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Walpy.VacancyApp.Server.Models.Responses
{
    /// <summary>
    /// Информация о запросе непрошедшем валидацию
    /// </summary>
    public class BadModelResponse : CustomErrorResponse
    {
        /// <summary>
        /// Все ошибки валидации, сгруппированные по полям
        /// </summary>
        /// <example>{ "Title": [ "The field Title is invalid." ],  "Salary": [ "The field Salary must be between 0 and 1.79769313486232E+308." ] }</example>
        public Dictionary<string, string[]> Errors { get; set; }

        /// <summary>
        /// Перечисление полей с ошибками валидации
        /// </summary>
        /// <example>[ "Title", "Salary" ]</example>
        public List<string> Fields { get; set; }

        /// <summary>
        /// Общее описание ошибки
        /// </summary>
        /// <example>One or more validation errors occurred.</example>
        public string Title => "One or more validation errors occurred.";

        /// <summary>
        /// Http код ошибки
        /// </summary>
        /// <example>400</example>
        public override int StatusCode => StatusCodes.Status400BadRequest;
    }
}