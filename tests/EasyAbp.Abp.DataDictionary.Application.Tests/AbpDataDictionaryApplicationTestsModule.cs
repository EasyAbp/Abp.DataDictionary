using EasyAbp.Abp.DataDictionary.Domain.Tests;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DataDictionary.Application.Tests
{
    [DependsOn(typeof(AbpDataDictionaryDomainTestsModule),
        typeof(AbpDataDictionaryApplicationModule))]
    public class AbpDataDictionaryApplicationTestsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}