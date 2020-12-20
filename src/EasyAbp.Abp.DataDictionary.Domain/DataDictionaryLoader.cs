using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryLoader : IDataDictionaryLoader, ITransientDependency
    {
        public virtual List<DataDictionaryRule> ScanRules(Assembly assembly)
        {
            var dtoTypes = assembly.GetTypes();
            var rules = new List<DataDictionaryRule>();

            Parallel.ForEach(dtoTypes, (type) =>
            {
                var properties = type
                    .GetProperties()
                    .Where(p => p.IsDefined(typeof(DictionaryCodeFieldAttribute)) || p.IsDefined(typeof(DictionaryRenderFieldAttribute)))
                    .ToList();

                var codeProperties = properties.Where(p => p.IsDefined(typeof(DictionaryCodeFieldAttribute)));
                var renderProperties = properties.Where(p => p.IsDefined(typeof(DictionaryRenderFieldAttribute)));

                foreach (var codeProperty in codeProperties)
                {
                    var dictionaryCode = codeProperty.GetCustomAttribute<DictionaryCodeFieldAttribute>().DictionaryCode;
                    var renderProperty = renderProperties.FirstOrDefault(x => x.GetCustomAttribute<DictionaryRenderFieldAttribute>().DictionaryCode == dictionaryCode);
                    if (renderProperty == null)
                    {
                        continue;
                    }

                    rules.Add(new DataDictionaryRule
                    {
                        DictionaryCode = dictionaryCode,
                        DtoType = type,
                        RenderFieldProperty = renderProperty,
                        DictionaryCodeProperty = codeProperty
                    });
                }
            });

            return rules;
        }
    }
}