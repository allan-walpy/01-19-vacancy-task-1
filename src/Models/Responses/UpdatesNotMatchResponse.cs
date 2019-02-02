using App.Server.Models.Database;

namespace App.Server.Models.Responses
{
    public class UpdatesNotMatchResponse
    {
        public VacancyModel Actual { get; set; }
        public VacancyModel Excpected { get; set; }
    }
}