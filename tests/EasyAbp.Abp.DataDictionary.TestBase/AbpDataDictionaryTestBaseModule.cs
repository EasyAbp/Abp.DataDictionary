using System;
using Microsoft.Extensions.DependencyInjection;
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
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            SetTestData(context.ServiceProvider);
        }

        private void SetTestData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<AbpDataDictionaryTestDataBuilder>()
                    .Build();
            }
        }
    }
}