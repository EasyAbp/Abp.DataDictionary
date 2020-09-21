using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary.HttpApi
{
    [DependsOn(typeof(AbpDataDictionaryApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AbpDataDictionaryHttpApiModule : AbpModule
    {
    }
}