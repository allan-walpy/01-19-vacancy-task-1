using Walpy.VacancyApp.Server.Core.Database;

namespace Walpy.VacancyApp.Server.All.Services
{
    public interface IDatabaseOrganizationService
        : IDatabaseTableService<OrganizationModel, string>
    {
        OrganizationModel GetByName(string name);

        OrganizationModel GetWithVacancies(string id);
    }
}