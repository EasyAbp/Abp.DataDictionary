using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpDataDictionaryDomainModule))]
    public class AbpDataDictionaryEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DataDictionaryDbContext>();
        }
    }
}