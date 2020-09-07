using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.DataDictionary.Domain.Tests
{
    public class DataDictionaryRule_Tests : AbpDataDictionaryDomainTestBase
    {
        private readonly IDataDictionaryLoader _dictionaryLoader;

        public DataDictionaryRule_Tests()
        {
            _dictionaryLoader = GetRequiredService<IDataDictionaryLoader>();
        }

        [Fact]
        public void Should_Scan_A_Rule()
        {
            // Arrange & Act
            var result = _dictionaryLoader.ScanRules(typeof(AbpDataDictionaryDomainTestBase).Assembly);

            // Assert
            result.Count.ShouldBeGreaterThan(0);
            result.Any(x => x.DictionaryCode == "Sex").ShouldBe(true);
        }

        [Fact]
        public async Task Should_Render_Dto_FieldName()
        {
            // Arrange
            var renderer = GetRequiredService<IDataDictionaryRenderer>();
            var dto = new DemoDto
            {
                Sex = "1"
            };

            // Act
            await renderer.RenderAsync(dto);
            
            // Assert
            dto.SexDescription.ShouldBe("男");
        }
    }

    public class DemoDto
    {
        [DictionaryCodeField("Sex")] 
        public string Sex { get; set; }

        [DictionaryRenderField] 
        public string SexDescription { get; set; }
    }
}