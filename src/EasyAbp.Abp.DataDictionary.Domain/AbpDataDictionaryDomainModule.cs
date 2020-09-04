using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpDddDomainModule),
        typeof(AbpDataDictionaryDomainSharedModule))]
    public class AbpDataDictionaryDomainModule : AbpModule
    {
    }
}