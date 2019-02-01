using App.Server.Models.Database;

namespace App.Server.Services
{
    public sealed class VacancyControllerService
    {
        private IDatabaseVacancyService VacancyService { get; }

        public VacancyControllerService(IDatabaseVacancyService vacancyService)
        {
            VacancyService = vacancyService;
        }

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
            => VacancyService.Delete(id);
    }
}