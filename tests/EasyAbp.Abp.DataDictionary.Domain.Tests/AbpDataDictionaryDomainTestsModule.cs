using System;
using EasyAbp.Abp.DataDictionary.EntityFrameworkCore.Tests;
using Volo.Abp.Modularity;
using Xunit;

namespace EasyAbp.Abp.DataDictionary.Domain.Tests
{
    [DependsOn(typeof(AbpDataDictionaryTestBaseModule),
        typeof(AbpDataDictionaryEntityFrameworkCoreTestsModule))]
    public class AbpDataDictionaryDomainTestsModule : AbpModule
    {
    }
}