using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using App.Server.Models.Database;

namespace App.Server.Services
{
    public class DatabaseOrganizationService
        : DatabaseTableService<OrganizationModel, string>, IDatabaseOrganizationService
    {
        protected IDatabaseVacancyService VacancyService { get; }

        public DatabaseOrganizationService(
            IDatabaseService databaseService,
            IDatabaseVacancyService vacancyService)
            : base(
                onAddAction: null,
                onUpdateAction: null,
                databaseService: databaseService)
        {
            VacancyService = vacancyService;
        }

        protected override DbSet<OrganizationModel> GetTable(DatabaseContext databaseContext)
            => databaseContext.Organizations;

        protected override string GetId(OrganizationModel item)
            => item.Id;

        public override OrganizationModel Update(string id, OrganizationModel updatedItem)
            => throw new InvalidOperationException("Organization records can't be updated");

        private bool NamePredicateMethod(OrganizationModel item, string requestName)
            => String.Compare(item.Name, requestName, StringComparison.InvariantCulture) == 0;

        public OrganizationModel GetByName(string name)
        {
            using (var databaseContext = DatabaseService.GetContext())
            {
                return GetTable(databaseContext)
                    .Where((organization) => NamePredicateMethod(organization, name))
                    .SingleOrDefault();
            }
        }

        public OrganizationModel GetWithVacancies(string id)
        {
            var result = Get(id);
            result.Vacancies = VacancyService.GetRangeBy((vacancy) => vacancy.OrganizationId == id);
            return result;
        }
    }
}