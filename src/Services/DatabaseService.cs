using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Walpy.VacancyApp.Server.Models.Database;

namespace Walpy.VacancyApp.Server.Services
{
    public class DatabaseService : IDatabaseService
    {
        public const string DbInMemmoryConfigKey = "database:test";
        public const string ConfigConnectionNameKey = "database:connection";
        public const string ConnectionKeyPrefix = "database";

        private string ConnectionString { get; }
        private ILoggerFactory LoggerFactory { get; }
        private ILogger<DatabaseService> Logger { get; }
        private IConfiguration Config { get; }

        public DatabaseService(IConfiguration config, ILoggerFactory loggerFactory)
        {
            Config = config;
            LoggerFactory = loggerFactory;
            Logger = loggerFactory.CreateLogger<DatabaseService>();

            ConnectionString = GetConnectionString();
        }

        private string GetConnectionString()
        {
            //TODO:FIXME: add LogEvents class;
            var logEventId = $"{nameof(DatabaseService)}:{nameof(GetConnectionString)}";
            var isDebug = Config.GetValue<bool>(Program.IsDevEnviromentConfigKey);

            var connectionName = $"{Config[ConfigConnectionNameKey]}:{(isDebug ? "debug" : "production")}";
            Logger.LogDebug(logEventId, "Fetched connection name for database {connectionName}", connectionName);

            var connectionKey = $"{ConnectionKeyPrefix}:{connectionName}";
            Logger.LogDebug(logEventId, "Fetched connection string key for database {connectionKey}", connectionKey);

            var connectionString = Config.GetSection("ConnetionStrings")[connectionKey];
            Logger.LogTrace(logEventId, "Fetched connection string for database {connectionString}", connectionString);

            return connectionString;
        }

        private DbContextOptions<DatabaseContext> GetDatabaseOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseLoggerFactory(LoggerFactory);

            var useInMemmoryDatabase = Config.GetValue<bool>(DbInMemmoryConfigKey);

            if (useInMemmoryDatabase)
            {
                UseInMemoryDatabase(optionsBuilder);
            }
            else
            {
                optionsBuilder.UseMySQL(ConnectionString);
            }

            return optionsBuilder.Options;
        }

        private void UseInMemoryDatabase(DbContextOptionsBuilder<DatabaseContext> optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(
                databaseName: "database_test"
            );
        }

        public DatabaseContext GetContext()
        {
            var options = GetDatabaseOptions();
            var result = new DatabaseContext(options);
            Logger.LogTrace($"{nameof(DatabaseService)}:{nameof(GetContext)}", "Fetched DatabaseContext with {ConnectionString}", ConnectionString);
            return result;
        }
    }
}