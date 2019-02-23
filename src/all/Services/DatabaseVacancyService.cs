using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Walpy.VacancyApp.Server.Core.Types;
using Walpy.VacancyApp.Server.Core.Database;

namespace Walpy.VacancyApp.Server.All.Services
{
    public class DatabaseVacancyService
        : DatabaseTableService<VacancyModel, string>, IDatabaseVacancyService
    {
        public DatabaseVacancyService(IDatabaseService databaseService)
            : base(
                onAddAction: OnVacancyAddAction,
                onUpdateAction: OnVacancyUpdateAction,
                databaseService: databaseService)
        { }

        protected static void OnVacancyAddAction(VacancyModel vacancy)
        {
            var timestamp = Program.CurrentTimestamp;
            vacancy.CreatedAt = timestamp;
            vacancy.LastUpdated = timestamp;
        }

        public static void OnVacancyUpdateAction(VacancyModel vacancy)
        {
            vacancy.LastUpdated = Program.CurrentTimestamp;
        }

        protected override DbSet<VacancyModel> GetTable(DatabaseContext databaseContext)
            => databaseContext.Vacancies;

        protected override string GetId(VacancyModel item)
            => item.Id;

        public VacancyModel Update(string id, VacancyUpdateModel updateRequest)
        {
            var vacancy = Get(id);
            if (vacancy == null)
            {
                return null;
            }

            vacancy.Update(updateRequest);
            return Update(id, updatedItem: vacancy);
        }

        public List<VacancyModel> GetRangeBy(Func<VacancyModel, bool> predicate)
        {
            using (var databaseContext = DatabaseService.GetContext())
            {
                return GetTable(databaseContext)
                    .Where(predicate).ToList()
                    .SortByLastUpdatedDescending();
            }
        }
    }
}