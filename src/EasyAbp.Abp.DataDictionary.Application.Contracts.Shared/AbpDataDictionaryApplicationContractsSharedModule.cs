using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(
        typeof(AbpDataDictionaryDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule))]
    public class AbpDataDictionaryApplicationContractsSharedModule : AbpModule
    {
    }
}