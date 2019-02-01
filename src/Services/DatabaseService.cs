using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using App.Server.Models.Database;

namespace App.Server.Services
{
    public class DatabaseService
    {
        public const string ConfigConnectionNameKey = "database";
        public const string ConnectionKeyPrefix = "database";

        private string ConnectionString { get; }
        private ILoggerFactory LoggerFactory { get; }
        private ILogger<DatabaseService> Logger { get; }

        public DatabaseService(IConfiguration config, ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
            Logger = loggerFactory.CreateLogger<DatabaseService>();

            ConnectionString = GetConnectionString(config);
        }

        private string GetConnectionString(IConfiguration config)
        {
            //TODO:FIXME: add LogEvents class;
            var logEventId = $"{nameof(DatabaseService)}:{nameof(GetConnectionString)}";
            var isDebug = config.GetValue<bool>(Startup.IsDevEnviromentConfigKey);

            var connectionName = $"{config[ConfigConnectionNameKey]}:{(isDebug ? "debug" : "production")}";
            Logger.LogDebug(logEventId, "Fetched connection name for database {connectionName}", connectionName);

            var connectionKey = $"{ConnectionKeyPrefix}:{connectionName}";
            Logger.LogDebug(logEventId, "Fetched connection string key for database {connectionKey}", connectionKey);

            var connectionString = config.GetSection("ConnetionStrings")[connectionKey];
            Logger.LogTrace(logEventId, "Fetched connection string for database {connectionString}", connectionString);

            return connectionString;
        }

        private DbContextOptions<DatabaseContext> GetDatabaseOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseLoggerFactory(LoggerFactory);
            optionsBuilder.UseMySQL(ConnectionString);

            return optionsBuilder.Options;
        }

        public DatabaseContext GetContext()
        {
            var options = GetDatabaseOptions();
            var result = new DatabaseContext(options);
            Logger.LogTrace($"{nameof(DatabaseService)}:{nameof(GetContext)}", "Fetched DatabaseContext with {ConnectionString}", ConnectionString);
            return result;
        }

        public DbSet<VacancyModel> GetVacanciesTable(DatabaseContext databaseContext)
            => databaseContext.Vacancies;

        public DbSet<OrganizationModel> GetOrganizationsTable(DatabaseContext databaseContext)
            => databaseContext.Organizations;

        public void OnVacancyAdd(VacancyModel vacancy)
        {
            var timestamp = Program.CurrentTimestamp;
            vacancy.CreatedAt = timestamp;
            vacancy.LastUpdated = timestamp;
        }

        public void OnVacancyUpdate(VacancyModel vacancy)
        {
            vacancy.LastUpdated = Program.CurrentTimestamp;
        }

        private (bool, VacancyModel) Exists(string vacancyId)
        {
            var vacancy = Get(vacancyId);
            var isFounded = (vacancy == null);
            return (isFounded, vacancy);
        }

        public VacancyModel Get(string vacancyId)
        {
            using (var databaseContext = GetContext())
            {
                return databaseContext.Vacancies.Find(vacancyId);
            }
        }

        public string Add(VacancyModel vacancy)
        {
            OnVacancyAdd(vacancy);
            using (var databaseContext = GetContext())
            {
                databaseContext.Vacancies.Add(vacancy);
                databaseContext.SaveChanges();
                return vacancy.Id.ToString();
            }
        }

        public bool Update(string vacancyId, VacancyUpdateModel update)
        {
            var (isExists, vacancy) = Exists(vacancyId);
            if (!isExists)
            {
                return false;
            }

            vacancy.Update(update);
            OnVacancyUpdate(vacancy);
            using (var databaseContext = GetContext())
            {
                databaseContext.Vacancies.Update(vacancy);
                return databaseContext.SaveChanges() > 0;
            }
        }

        public bool Delete(string vacancyId)
        {
            var (isExists, vacancy) = Exists(vacancyId);
            if (!isExists)
            {
                return false;
            }

            using (var databaseContext = GetContext())
            {
                databaseContext.Vacancies.Remove(vacancy);
                return databaseContext.SaveChanges() > 0;
            }
        }

        public List<VacancyModel> GetRangeBy(Func<VacancyModel, bool> predicate)
        {
            using (var databaseContext = GetContext())
            {
                return databaseContext.Vacancies.Where(predicate).ToList();
            }
        }
    }
}