namespace Walpy.VacancyApp.Server.Models.Responses
{
    public class CustomErrorResponse
    {
        /// <summary>
        /// Http код ошибки
        /// </summary>
        /// <example>400</example>
        public int StatusCode { get; set; }

        protected CustomErrorResponse(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}