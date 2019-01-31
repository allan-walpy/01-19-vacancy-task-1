using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using App.Server;
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

        private DatabaseContext GetContext()
        {
            var options = GetDatabaseOptions();
            var result = new DatabaseContext(options);
            Logger.LogTrace($"{nameof(DatabaseService)}:{nameof(GetContext)}", "Fetched DatabaseContext with {ConnectionString}", ConnectionString);
            return result;
        }

        private void OnVacancyAdd(VacancyModel vacancy, long timestamp)
        {
            vacancy.CreatedAt = timestamp;
            vacancy.LastUpdated = timestamp;
        }

        private void OnVacancyUpdate(VacancyModel vacancy, long timestamp)
        {

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
            using (var databaseContext = GetContext())
            {
                databaseContext.Vacancies.Add(vacancy);
                databaseContext.SaveChanges();
                return vacancy.Id.ToString();
            }
        }

        public bool Update(string vacancyId, object update)
        {
            var vacancy = Get(vacancyId);
            if (vacancy == null)
            {
                return false;
            }

            using (var databaseContext = GetContext())
            {
                //TODO:FIXME:;
                throw new NotImplementedException();
            }
        }
    }
}