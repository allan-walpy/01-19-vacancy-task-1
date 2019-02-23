using Walpy.VacancyApp.Server.Core.Database;

namespace Walpy.VacancyApp.Server.All.Services
{
    public interface IDatabaseService
    {
        DatabaseContext GetContext();
    }
}