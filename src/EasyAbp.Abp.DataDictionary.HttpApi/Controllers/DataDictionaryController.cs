using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DataDictionary.HttpApi.Controllers
{
    [RemoteService(Name = DataDictionaryRemoteServiceConsts.RemoteServiceName)]
    [Route("api/data-dictionary/data-dictionary")]
    public class DataDictionaryController : DataDictionaryBaseController, IDataDictionaryAppService
    {
        private readonly IDataDictionaryAppService _dataDictionaryAppService;

        public DataDictionaryController(IDataDictionaryAppService dataDictionaryAppService)
        {
            _dataDictionaryAppService = dataDictionaryAppService;
        }

        [HttpPost]
        public Task<DataDictionaryDto> CreateAsync(DataDictionaryCreateDto input) => _dataDictionaryAppService.CreateAsync(input);

        [HttpPut]
        [Route("{id}")]
        public Task<DataDictionaryDto> UpdateAsync(Guid id, DataDictionaryUpdateDto input) => _dataDictionaryAppService.UpdateAsync(id, input);

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id) => _dataDictionaryAppService.DeleteAsync(id);

        [HttpGet]
        [Route("{id}")]
        public Task<DataDictionaryDto> GetAsync(Guid id) => _dataDictionaryAppService.GetAsync(id);

        [HttpGet]
        public Task<PagedResultDto<DataDictionaryDto>> GetListAsync(PagedResultRequestDto input) => _dataDictionaryAppService.GetListAsync(input);
    }
}