using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.DataDictionary.Domain.Tests
{
    public class CacheDataDictionaryValueProvider_Tests : AbpDataDictionaryDomainTestBase
    {
        [Fact]
        public async Task Should_Render_Value_From_Cache_Renderer()
        {
            // Arrange
            var options = GetRequiredService<IOptions<AbpDataDictionaryOptions>>().Value;
            var rules = GetRequiredService<IDataDictionaryLoader>().ScanRules(typeof(AbpDataDictionaryDomainTestBase).Assembly);
            options.Rules.AddRange(rules);
            var render = GetRequiredService<IDataDictionaryRenderer>();
            
            var renderDto = new WaitCacheRenderDto
            {
                Level = "2",
                Grade = "2"
            };

            // Act
            await render.RenderAsync(renderDto);

            // Assert
            renderDto.LevelValue.ShouldBe("大专");
            renderDto.GradeValue.ShouldBe("二级");
        }
    }

    public class WaitCacheRenderDto
    {
        [DictionaryCodeField("XL")]
        public string Level { get; set; }

        [DictionaryRenderField("XL")]
        public string LevelValue { get; set; }


        [DictionaryCodeField("DJ")]
        public string Grade { get; set; }

        [DictionaryRenderField("DJ")]
        public string GradeValue { get; set; }
    }
}