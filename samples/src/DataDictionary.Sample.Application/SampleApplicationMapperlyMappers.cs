using DataDictionary.Sample.Student;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace DataDictionary.Sample
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class StudentEntityToStudentDtoMapper : MapperBase<StudentEntity, StudentDto>
    {
        public override partial StudentDto Map(StudentEntity source);
        public override partial void Map(StudentEntity source, StudentDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class StudentEntityToStudentGetListOutputDtoMapper : MapperBase<StudentEntity, StudentGetListOutputDto>
    {
        // LevelValue is not present on the entity; it is populated later by the data dictionary renderer.
        [MapperIgnoreTarget(nameof(StudentGetListOutputDto.LevelValue))]
        public override partial StudentGetListOutputDto Map(StudentEntity source);

        [MapperIgnoreTarget(nameof(StudentGetListOutputDto.LevelValue))]
        public override partial void Map(StudentEntity source, StudentGetListOutputDto destination);
    }
}
