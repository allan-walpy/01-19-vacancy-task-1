using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using App.Server.Models.Database;

namespace App.Server.Services
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

        public VacancyModel Update(string id, VacancyUpdateModel update)
        {
            var vacancy = Get(id);
            if (vacancy == null)
            {
                return null;
            }

            vacancy.Update(update);
            return Update(id, updatedItem: vacancy);
        }

        public List<VacancyModel> GetRangeBy(Func<VacancyModel, bool> predicate)
        {
            using (var databaseContext = DatabaseService.GetContext())
            {
                var result = GetTable(databaseContext).Where(predicate).ToList();

                //? `LastUpdate` descending sorting;
                result.Sort((vacancy1, vacancy2) => (int)(vacancy2.LastUpdated - vacancy1.LastUpdated));
                return result;
            }
        }
    }
}