using App.Server.Models.Database;

namespace App.Server.Services
{
    public interface IDatabaseOrganizationService
        : IDatabaseTableService<OrganizationModel, string>
    {
        OrganizationModel GetByName(string name);
    }
}