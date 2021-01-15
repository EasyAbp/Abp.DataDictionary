using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DataDictionary.Sample.Student
{
    public class StudentAppService : CrudAppService<StudentEntity, StudentDto, StudentGetListOutputDto, Guid, GetStudentListInputDto, StudentCreateDto, StudentUpdateDto>,
        IStudentAppService
    {
        public StudentAppService(IRepository<StudentEntity, Guid> repository) : base(repository)
        {
        }
    }
}