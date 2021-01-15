using Volo.Abp.Modularity;

namespace DataDictionary.Sample
{
    [DependsOn(
        typeof(SampleApplicationModule),
        typeof(SampleDomainTestModule)
        )]
    public class SampleApplicationTestModule : AbpModule
    {

    }
}