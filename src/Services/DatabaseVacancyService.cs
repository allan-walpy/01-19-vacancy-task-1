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
        public DatabaseVacancyService(DatabaseService databaseService)
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

        public List<VacancyModel> GetRangeBy(Func<VacancyModel, bool> predicate)
        {
            using (var databaseContext = DatabaseService.GetContext())
            {
                return GetTable(databaseContext).Where(predicate).ToList();
            }
        }
    }
}