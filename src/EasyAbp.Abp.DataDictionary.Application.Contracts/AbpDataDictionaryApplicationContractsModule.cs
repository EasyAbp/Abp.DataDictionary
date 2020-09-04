using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpDataDictionaryApplicationContractsSharedModule))]
    public class AbpDataDictionaryApplicationContractsModule : AbpModule
    {
    }
}