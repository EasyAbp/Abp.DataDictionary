using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpDataDictionaryApplicationContractsModule),
        typeof(AbpDataDictionaryDomainModule),
        typeof(AbpAutoMapperModule))]
    public class AbpDataDictionaryApplicationModule : AbpModule
    {
    }
}