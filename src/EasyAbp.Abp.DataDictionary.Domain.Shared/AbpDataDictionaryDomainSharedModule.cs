using EasyAbp.Abp.DataDictionary.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.Abp.DataDictionary
{
    [DependsOn(typeof(AbpValidationModule))]
    public class AbpDataDictionaryDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpDataDictionaryDomainSharedModule>("EasyAbp.Abp.DataDictionary");
            });
            
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<DataDictionaryResource>("en")
                    .AddVirtualJson("/Localization/Resources");
                
                options.DefaultResourceType = typeof(DataDictionaryResource);
            });
        }
    }
}