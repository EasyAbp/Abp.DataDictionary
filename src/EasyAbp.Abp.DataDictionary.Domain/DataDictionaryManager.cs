using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryManager : DomainService, IDataDictionaryManager
    {
        protected readonly IDataDictionaryRepository DataDictionaryRepository;
        protected readonly IStringLocalizer<DataDictionaryResource> StringLocalizer;

        public DataDictionaryManager(IDataDictionaryRepository dataDictionaryRepository,
            IStringLocalizer<DataDictionaryResource> stringLocalizer)
        {
            DataDictionaryRepository = dataDictionaryRepository;
            StringLocalizer = stringLocalizer;
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
                throw new UserFriendlyException(StringLocalizer["DataDictionary:ValidateDuplicate", code]);
            }
        }
    }
}