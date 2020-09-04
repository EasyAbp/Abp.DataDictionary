using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpDataDictionaryDomainSharedModule))]
    public class AbpDataDictionaryApplicationContractsSharedModule : AbpModule
    {
    }
}