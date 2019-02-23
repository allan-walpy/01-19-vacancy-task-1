namespace Walpy.VacancyApp.Server.All.Models.Responses
{
    /// <summary>
    /// Информация о несоответствии обновленной вакансии ожидаемой
    /// </summary>
    public class UpdatesNotMatchResponse
    {
        /// <summary>
        /// Вакансия, что сохранилась в базу данных
        /// </summary>
        public VacancyResponse Actual { get; set; }

        /// <summary>
        /// Вакансия, что должна была сохраниться в базу данных
        /// </summary>
        public VacancyResponse Excpected { get; set; }
    }
}