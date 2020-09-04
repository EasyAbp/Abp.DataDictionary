using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryAppService : ApplicationService, IDataDictionaryAppService
    {
        // private readonly IDataDictionaryRepository _dataDictionaryRepository;

        public DataDictionaryAppService(/*IDataDictionaryRepository dataDictionaryRepository*/)
        {
            // _dataDictionaryRepository = dataDictionaryRepository;
        }

        public Task<DataDictionaryDto> CreateAsync(DataDictionaryCreateDto input)
        {
            throw new NotImplementedException();
        }

        public Task<DataDictionaryDto> UpdateAsync(Guid id, DataDictionaryUpdateDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DataDictionaryDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<DataDictionaryDto>> GetListAsync(PagedResultRequestDto input)
        {
            throw new NotImplementedException();
        }
    }
}