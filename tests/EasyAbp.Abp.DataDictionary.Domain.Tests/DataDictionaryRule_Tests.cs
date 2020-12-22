using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.DataDictionary.Domain.Tests
{
    public class DataDictionaryRule_Tests : AbpDataDictionaryDomainTestBase
    {
        protected override void AfterAddApplication(IServiceCollection services)
        {
            services.AddTransient<IDataDictionaryValueProvider, TestRuleValueProvider>();
        }

        private readonly IDataDictionaryLoader _dictionaryLoader;
        private readonly AbpDataDictionaryOptions _abpDataDictionaryOptions;

        public DataDictionaryRule_Tests()
        {
            _dictionaryLoader = GetRequiredService<IDataDictionaryLoader>();
            _abpDataDictionaryOptions = GetRequiredService<IOptions<AbpDataDictionaryOptions>>().Value;
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
            _abpDataDictionaryOptions.Rules.AddRange(_dictionaryLoader.ScanRules(typeof(AbpDataDictionaryDomainTestBase).Assembly));
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

        [DictionaryRenderField("Sex")] 
        public string SexDescription { get; set; }
    }

    public class TestRuleValueProvider : IDataDictionaryValueProvider
    {
        private readonly List<DataDictionaryItemInfo> _itemInfos;

        public TestRuleValueProvider()
        {
            _itemInfos = new List<DataDictionaryItemInfo>
            {
                new DataDictionaryItemInfo
                {
                    DictionaryCode = "Sex",
                    ItemCode = "1",
                    ItemDisplayText = "男"
                },
                new DataDictionaryItemInfo
                {
                    DictionaryCode = "Sex",
                    ItemCode = "2",
                    ItemDisplayText = "女"
                }
            };
        }

        public Task<string> GetValueAsync(string dictCode, string itemCode)
        {
            return Task.FromResult(_itemInfos.First(i => i.DictionaryCode == dictCode && i.ItemCode == itemCode).ItemDisplayText);
        }
    }
}