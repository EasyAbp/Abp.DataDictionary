using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace DataDictionary.Sample.EntityFrameworkCore
{
    [DependsOn(
        typeof(SampleEntityFrameworkCoreModule)
        )]
    public class SampleEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SampleMigrationsDbContext>();
        }
    }
}
