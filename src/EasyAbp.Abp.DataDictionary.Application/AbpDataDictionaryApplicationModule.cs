using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpDataDictionaryApplicationContractsModule),
        typeof(AbpDataDictionaryDomainModule),
        typeof(AbpAutoMapperModule))]
    public class AbpDataDictionaryApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper();
            Configure<AbpAutoMapperOptions>(op =>
            {
                op.AddProfile<DataDictionaryAutoMapperProfile>();
            });
        }
    }
}