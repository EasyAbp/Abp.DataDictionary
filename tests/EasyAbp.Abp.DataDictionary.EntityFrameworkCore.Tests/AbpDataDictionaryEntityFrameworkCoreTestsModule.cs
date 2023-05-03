using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DataDictionary.EntityFrameworkCore.Tests
{
    [DependsOn(typeof(AbpEntityFrameworkCoreSqliteModule),
        typeof(AbpDataDictionaryTestBaseModule),
        typeof(AbpDataDictionaryEntityFrameworkCoreModule))]
    public class AbpDataDictionaryEntityFrameworkCoreTestsModule : AbpModule
    {
        private SqliteConnection _sqliteConnection;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAlwaysDisableUnitOfWorkTransaction();
            _sqliteConnection = CreateDatabaseAndGetConnection();
            Configure<AbpDbContextOptions>(op =>
            {
                op.Configure(configurationContext =>
                {
                    configurationContext.DbContextOptions.UseSqlite(_sqliteConnection);
                });
            });
        }

        private SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DataDictionaryDbContext>().UseSqlite(connection).Options;
            using (var dbContext = new DataDictionaryDbContext(options))
            {
                dbContext.GetService<IRelationalDatabaseCreator>().CreateTables();
            }

            return connection;
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            _sqliteConnection.Dispose();
        }
    }
}