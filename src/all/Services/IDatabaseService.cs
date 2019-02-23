using Walpy.VacancyApp.Server.All.Models.Database;

namespace Walpy.VacancyApp.Server.All.Services
{
    public interface IDatabaseService
    {
        DatabaseContext GetContext();
    }
}