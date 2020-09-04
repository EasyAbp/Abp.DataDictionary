using Volo.Abp.Modularity;
using Volo.Abp.Validation;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpValidationModule))]
    public class AbpDataDictionaryDomainSharedModule : AbpModule
    {
    }
}