using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.Mapperly;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpDataDictionaryApplicationContractsModule),
        typeof(AbpDataDictionaryDomainModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpMapperlyModule))]
    public class AbpDataDictionaryApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMapperlyObjectMapper<AbpDataDictionaryApplicationModule>();
        }
    }
}
