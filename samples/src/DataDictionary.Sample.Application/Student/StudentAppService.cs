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

        // The entity is built and updated explicitly because Mapperly cannot write the entity's
        // protected setters or call its protected constructor.
        protected override Task<StudentEntity> MapToEntityAsync(StudentCreateDto createInput)
        {
            return Task.FromResult(new StudentEntity(
                GuidGenerator.Create(),
                createInput.Name,
                createInput.Age,
                createInput.Description,
                createInput.Sex,
                createInput.Level));
        }

        protected override Task MapToEntityAsync(StudentUpdateDto updateInput, StudentEntity entity)
        {
            entity.Update(
                updateInput.Age,
                updateInput.Description,
                updateInput.Sex,
                updateInput.Level);

            return Task.CompletedTask;
        }
    }
}