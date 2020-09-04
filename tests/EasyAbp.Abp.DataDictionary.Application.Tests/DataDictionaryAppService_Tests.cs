using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.Dtos;
using Volo.Abp.Guids;
using Xunit;

namespace EasyAbp.Abp.DataDictionary.Application.Tests
{
    public class DataDictionaryAppService_Tests : AbpDataDictionaryApplicationTestBase
    {
        private readonly IDataDictionaryAppService _dataDictionaryAppService;

        public DataDictionaryAppService_Tests()
        {
            _dataDictionaryAppService = GetRequiredService<IDataDictionaryAppService>();
        }

        [Fact]
        public async Task Should_Create_A_DataDictionary()
        {
            // Arrange
            var requestDto = new DataDictionaryCreateDto();

            // Act
            var response = await _dataDictionaryAppService.CreateAsync(requestDto);

            // Assert
        }
    }
}