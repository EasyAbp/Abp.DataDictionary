using System;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DataDictionary
{
    public class AbpDataDictionaryTestData : ISingletonDependency
    {
        public Guid DataDictionary1 { get; } = Guid.NewGuid();
        public Guid DataDictionary2 { get; } = Guid.NewGuid();
        
        public Guid DataDictionary3 { get; } = Guid.NewGuid();
    }
}