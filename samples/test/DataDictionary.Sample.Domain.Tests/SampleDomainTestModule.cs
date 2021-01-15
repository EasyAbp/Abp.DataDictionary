using DataDictionary.Sample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DataDictionary.Sample
{
    [DependsOn(
        typeof(SampleEntityFrameworkCoreTestModule)
        )]
    public class SampleDomainTestModule : AbpModule
    {

    }
}