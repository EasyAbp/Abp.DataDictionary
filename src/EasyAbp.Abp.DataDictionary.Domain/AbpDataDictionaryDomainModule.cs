using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpDddDomainModule),
        typeof(AbpDataDictionaryDomainSharedModule),
        typeof(AbpCachingModule))]
    public class AbpDataDictionaryDomainModule : AbpModule
    {
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
        }
    }
}