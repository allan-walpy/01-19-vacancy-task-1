using Walpy.VacancyApp.Server.Models.Database;

namespace Walpy.VacancyApp.Server.Services
{
    public interface IDatabaseOrganizationService
        : IDatabaseTableService<OrganizationModel, string>
    {
        OrganizationModel GetByName(string name);

        OrganizationModel GetWithVacancies(string id);
    }
}