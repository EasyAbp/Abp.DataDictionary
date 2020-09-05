using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryManager : DomainService, IDataDictionaryManager
    {
        protected readonly IDataDictionaryRepository DataDictionaryRepository;

        public DataDictionaryManager(IDataDictionaryRepository dataDictionaryRepository)
        {
            DataDictionaryRepository = dataDictionaryRepository;
        }

        public virtual async Task CreateAsync(DataDictionary dict)
        {
            await ValidateDictionaryAsync(dict.Code);
            await DataDictionaryRepository.InsertAsync(dict);
        }

        public virtual async Task UpdateAsync(DataDictionary dict)
        {
            await ValidateDictionaryAsync(dict.Code, dict.Id);
            await DataDictionaryRepository.UpdateAsync(dict);
        }

        protected virtual async Task ValidateDictionaryAsync(string code, Guid? expectedId = null)
        {
            var dict = await DataDictionaryRepository.FindAsync(d => d.Code == code);
            if (dict != null && dict.Id != expectedId)
            {
                throw new UserFriendlyException($"不能编码为({code})的数据字典，已经存在该编码的数据字典。");
            }
        }
    }
}