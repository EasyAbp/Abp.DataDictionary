using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryAppService : IApplicationService
    {
        Task<DataDictionaryDto> CreateAsync(DataDictionaryCreateDto input);

        Task<DataDictionaryDto> UpdateAsync(Guid id, DataDictionaryUpdateDto input);

        Task DeleteAsync(Guid id);

        Task<DataDictionaryDto> GetAsync(Guid id);

        Task<DataDictionaryDto> FindByCodeAsync(string code);

        Task<PagedResultDto<DataDictionaryDto>> GetListAsync(PagedResultRequestDto input);
    }
}