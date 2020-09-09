using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.Abp.DataDictionary.RuleValueProviders
{
    public class CacheDataDictionaryValueProvider : IDataDictionaryValueProvider, ITransientDependency
    {
        protected readonly IDistributedCache<DataDictionaryItemInfo> DistributedCache;
        protected readonly IDataDictionaryRepository DataDictionaryRepository;

        public CacheDataDictionaryValueProvider(IDistributedCache<DataDictionaryItemInfo> distributedCache,
            IDataDictionaryRepository dataDictionaryRepository)
        {
            DistributedCache = distributedCache;
            DataDictionaryRepository = dataDictionaryRepository;
        }

        public virtual async Task<string> GetValueAsync(string dictCode, string itemCode)
        {
            var cacheItem = await DistributedCache.GetOrAddAsync($"EasyAbp.DataDictionary.{dictCode}.{itemCode}", async () =>
            {
                var dict = await DataDictionaryRepository.FindAsync(d => d.Code == dictCode);
                var item = dict.Items.FirstOrDefault(i => i.Code == itemCode);
                if (item == null)
                {
                    // TODO: Should be localized.
                    throw new EntityNotFoundException("数据字典不存在，无法获取对应的值。");
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