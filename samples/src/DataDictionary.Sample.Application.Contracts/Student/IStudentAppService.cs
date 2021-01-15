using System;
using EasyAbp.Abp.DataDictionary;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DataDictionary.Sample.Student
{
    public class StudentCreateDto : StudentCreateOrUpdateDto
    {
        public string Name { get; set; }
    }

    public class StudentUpdateDto : StudentCreateOrUpdateDto
    {
    }

    public abstract class StudentCreateOrUpdateDto
    {
        public int Age { get; set; }

        public string Description { get; set; }

        public string Sex { get; set; }

        public string Level { get; set; }
    }

    public class StudentGetListOutputDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        [DictionaryCodeField("Sex")]
        [DictionaryRenderField("Sex")]
        public string Sex { get; set; }

        [DictionaryCodeField("Level")]
        public string Level { get; set; }

        [DictionaryRenderField("Level")]
        public string LevelValue { get; set; }
    }

    public class GetStudentListInputDto : PagedResultRequestDto
    {
        public string SearchKey { get; set; }
    }

    public class StudentDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public string Sex { get; set; }

        public string Level { get; set; }
    }

    public interface IStudentAppService : ICrudAppService<StudentDto, StudentGetListOutputDto, Guid, GetStudentListInputDto,
        StudentCreateDto, StudentUpdateDto>
    {
    }
}