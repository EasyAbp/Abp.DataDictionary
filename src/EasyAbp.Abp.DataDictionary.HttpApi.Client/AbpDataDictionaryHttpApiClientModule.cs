﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.Abp.DataDictionary.HttpApi.Client
{
    [DependsOn(typeof(AbpDataDictionaryApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AbpDataDictionaryHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(AbpDataDictionaryApplicationContractsModule).Assembly,
                DataDictionaryRemoteServiceConsts.RemoteServiceName);
            
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpDataDictionaryHttpApiClientModule>();
            });
        }
    }
}