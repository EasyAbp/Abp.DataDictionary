using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryRenderer : IDataDictionaryRenderer, ITransientDependency
    {
        protected readonly IList<IDataDictionaryRenderValueProvider> Providers;
        protected readonly AbpDataDictionaryOptions Options;

        public DataDictionaryRenderer(IList<IDataDictionaryRenderValueProvider> providers,
            IOptions<AbpDataDictionaryOptions> options)
        {
            Providers = providers;
            Options = options.Value;
        }

        public virtual async Task<TDto> RenderAsync<TDto>(TDto sourceDto)
        {
            var dtoType = typeof(TDto);
            var rule = Options.Rules.FirstOrDefault(r => r.DtoType == dtoType);
            if (rule == null)
            {
                return sourceDto;
            }

            foreach (var provider in Providers)
            {
                // TODO: Possible bug 1.
                var itemCode = (string) rule.DictionaryCodeProperty.GetValue(sourceDto);
                var value = await provider.GetValueAsync(rule.DictionaryCode, itemCode);
                rule.RenderFieldProperty.SetValue(sourceDto, value);
            }

            return sourceDto;
        }
    }
}