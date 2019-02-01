using App.Server.Models.Database;

namespace App.Server.Services
{
    public interface IDatabaseService
    {
        DatabaseContext GetContext();
    }
}