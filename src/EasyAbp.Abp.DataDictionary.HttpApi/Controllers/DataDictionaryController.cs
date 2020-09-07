using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DataDictionary.HttpApi.Controllers
{
    [RemoteService(Name = DataDictionaryRemoteServiceConsts.RemoteServiceName)]
    public class DataDictionaryController : DataDictionaryBaseController,IDataDictionaryAppService
    {
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