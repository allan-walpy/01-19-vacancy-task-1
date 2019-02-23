using Microsoft.AspNetCore.Http;

namespace Walpy.VacancyApp.Server.All.Models.Responses
{
    /// <summary>
    /// Содержит информацию о внутренней ошибке сервера
    /// </summary>
    public class ErrorResponse : CustomErrorResponse
    {
        /// <summary>
        /// Краткое сообщение об ошибке
        /// </summary>
        /// <value>Вакансии с данным id не было найдено\nParameter name: id\nActual value was 40213585-be3b-4ad6-a6f6-e5d1c2e5cb25.</value>
        public string Message { get; set; }

        /// <summary>
        /// Источник ошибки
        /// </summary>
        /// <value>Walpy.VacancyApp.Server.All</value>
        public string Source { get; set; }

        public ErrorResponse()
            : base(StatusCodes.Status500InternalServerError)
        { }
    }
}