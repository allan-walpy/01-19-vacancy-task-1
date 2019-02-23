using System.Collections.Generic;

using Walpy.VacancyApp.Server.Core.Database;

namespace Walpy.VacancyApp.Server.All.Services
{
    public sealed class VacancyControllerService
    {
        private IDatabaseVacancyService VacancyService { get; }
        private IDatabaseOrganizationService OrganizationService { get; }

        public VacancyControllerService(
            IDatabaseVacancyService vacancyService,
            IDatabaseOrganizationService organizationService)
        {
            VacancyService = vacancyService;
            OrganizationService = organizationService;
        }

        public List<VacancyModel> Get()
            => VacancyService.GetRangeBy((vacancy) => true);

        public VacancyModel Get(string id)
        {
            var result = VacancyService.Get(id);
            if (result != null)
            {
                result.Organization = OrganizationService.Get(result.OrganizationId);
            }

            return result;
        }

        public bool Exists(string id)
            => Get(id) != null;

        public string Add(VacancyModel vacancy)
            => VacancyService.Add(vacancy);

        public VacancyModel Update(string id, VacancyUpdateModel vacancyUpdate)
            => VacancyService.Update(id, vacancyUpdate);

        public bool Delete(string id)
        {
            var organizationId = Get(id)?.OrganizationId;
            bool success = VacancyService.Delete(id);

            if (success && organizationId != null)
            {
                var organization = OrganizationService.GetWithVacancies(organizationId);
                if (organization.Vacancies.Count == 0)
                {
                    OrganizationService.Delete(organizationId);
                }
            }

            return success;
        }
    }
}