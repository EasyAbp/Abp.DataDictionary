using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Localization;

namespace EasyAbp.Abp.DataDictionary.RuleValueProviders
{
    public class CacheDataDictionaryValueProvider : IDataDictionaryValueProvider, ITransientDependency
    {
        protected readonly IDistributedCache<DataDictionaryItemInfo> DistributedCache;
        protected readonly IDataDictionaryRepository DataDictionaryRepository;
        protected readonly IStringLocalizer<DataDictionaryResource> StringLocalizer;

        public CacheDataDictionaryValueProvider(IDistributedCache<DataDictionaryItemInfo> distributedCache,
            IDataDictionaryRepository dataDictionaryRepository,
            IStringLocalizer<DataDictionaryResource> stringLocalizer)
        {
            DistributedCache = distributedCache;
            DataDictionaryRepository = dataDictionaryRepository;
            StringLocalizer = stringLocalizer;
        }

        public virtual async Task<string> GetValueAsync(string dictCode, string itemCode)
        {
            var cacheItem = await DistributedCache.GetOrAddAsync($"EasyAbp.DataDictionary.{dictCode}.{itemCode}", async () =>
            {
                var dict = await DataDictionaryRepository.FindAsync(d => d.Code == dictCode);
                var item = dict.Items.FirstOrDefault(i => i.Code == itemCode);
                if (item == null)
                {
                    throw new EntityNotFoundException(StringLocalizer["DataDictionary:CacheItemNotFound"]);
                }

                return new DataDictionaryItemInfo
                {
                    DictionaryCode = dictCode,
                    ItemCode = itemCode,
                    ItemDisplayText = item.DisplayText
                };
            });

            return cacheItem.ItemDisplayText;
        }
    }
}