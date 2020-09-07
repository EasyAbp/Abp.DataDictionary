using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryLoader : IDataDictionaryLoader, ITransientDependency
    {
        public List<DataDictionaryRule> ScanRules(Assembly assembly)
        {
            var dtoTypes = assembly.GetTypes();
            var rules = new List<DataDictionaryRule>();

            foreach (var type in dtoTypes)
            {
                var properties = type
                    .GetProperties()
                    .Where(p => p.IsDefined(typeof(DictionaryCodeFieldAttribute)) || p.IsDefined(typeof(DictionaryRenderFieldAttribute)))
                    .ToList();
                if (properties.Count != 2) continue;

                var codeProperty = properties.First(p => p.IsDefined(typeof(DictionaryCodeFieldAttribute)));
                var renderProperty = properties.First(p => p.IsDefined(typeof(DictionaryRenderFieldAttribute)));

                rules.Add(new DataDictionaryRule
                {
                    DictionaryCode = codeProperty.GetCustomAttribute<DictionaryCodeFieldAttribute>().DictionaryCode,
                    DtoType = type,
                    RenderFieldProperty = renderProperty,
                    DictionaryCodeProperty = codeProperty
                });
            }

            return rules;
        }
    }
}