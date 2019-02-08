using Walpy.VacancyApp.Server.Models.Database;

namespace Walpy.VacancyApp.Server.Services
{
    public interface IDatabaseService
    {
        DatabaseContext GetContext();
    }
}