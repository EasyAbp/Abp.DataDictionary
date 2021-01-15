using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DataDictionary.Sample.Student
{
    public class StudentAppService : CrudAppService<StudentEntity, StudentDto, StudentGetListOutputDto, Guid, GetStudentListInputDto, StudentCreateDto, StudentUpdateDto>,
        IStudentAppService
    {
        private readonly IDataDictionaryRenderer _dataDictionaryRenderer;
        
        public StudentAppService(IRepository<StudentEntity, Guid> repository, IDataDictionaryRenderer dataDictionaryRenderer) : base(repository)
        {
            _dataDictionaryRenderer = dataDictionaryRenderer;
        }

        public override async Task<PagedResultDto<StudentGetListOutputDto>> GetListAsync(GetStudentListInputDto input)
        {
            var list = await base.GetListAsync(input);
            await _dataDictionaryRenderer.RenderListAsync(list.Items);

            return list;
        }
    }
}