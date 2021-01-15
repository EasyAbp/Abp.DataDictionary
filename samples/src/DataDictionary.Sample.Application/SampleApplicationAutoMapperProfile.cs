using AutoMapper;
using DataDictionary.Sample.Student;

namespace DataDictionary.Sample
{
    public class SampleApplicationAutoMapperProfile : Profile
    {
        public SampleApplicationAutoMapperProfile()
        {
            CreateMap<StudentEntity, StudentDto>();
            CreateMap<StudentEntity, StudentGetListOutputDto>();
            CreateMap<StudentCreateDto, StudentEntity>();
            CreateMap<StudentUpdateDto, StudentEntity>();
        }
    }
}