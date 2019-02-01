using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using App.Server.Models.Database;

namespace App.Server.Services
{
    public class DatabaseService : IDatabaseService
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
    }
}