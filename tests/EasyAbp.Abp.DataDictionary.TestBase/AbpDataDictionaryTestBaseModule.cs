using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpDataDictionaryDomainModule),
        typeof(AbpTestBaseModule),
        typeof(AbpAutofacModule))]
    public class AbpDataDictionaryTestBaseModule : AbpModule
    {
        
    }
}