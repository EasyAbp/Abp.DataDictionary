using EasyAbp.Abp.DataDictionary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace DataDictionary.Sample
{
    [DependsOn(
        typeof(SampleDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(SampleApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpDataDictionaryApplicationModule)
    )]
    public class SampleApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<SampleApplicationModule>();
                options.AddProfile<SampleApplicationAutoMapperProfile>();
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            using (var scope = context.ServiceProvider.CreateScope())
            {
                var rules = scope.ServiceProvider
                    .GetRequiredService<IDataDictionaryLoader>()
                    .ScanRules(typeof(SampleApplicationContractsModule).Assembly);

                scope.ServiceProvider
                    .GetRequiredService<IOptions<AbpDataDictionaryOptions>>()
                    .Value.Rules = rules;
            }
        }
    }
}