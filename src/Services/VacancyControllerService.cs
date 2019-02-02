using System.Collections.Generic;

using App.Server.Models.Database;

namespace App.Server.Services
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
            => VacancyService.Get(id);

        public bool Exists(string id)
            => Get(id) != null;

        public string Add(VacancyModel vacancy)
        {
            bool success = VacancyService.Add(vacancy);
            return success ? vacancy.Id : null;
        }

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