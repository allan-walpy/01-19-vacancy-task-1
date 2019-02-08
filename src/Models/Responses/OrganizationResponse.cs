namespace Walpy.VacancyApp.Server.Models.Responses
{
    /// <summary>
    /// Информация об организации
    /// </summary>
    public class OrganizationResponse
    {
        /// <summary>
        /// Guid записи в базе данных
        /// </summary>
        /// <example>07cc9f1a-7011-4e3e-a7da-e63a0cf839cb</example>
        public string Id { get; set; }

        /// <summary>
        /// Название организации
        /// </summary>
        /// <example>ООО "Скучная компания"</example>
        public string Name { get; set; }
    }
}