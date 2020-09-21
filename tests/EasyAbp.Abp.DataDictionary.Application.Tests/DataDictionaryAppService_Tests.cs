using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.Dtos;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Xunit;

namespace EasyAbp.Abp.DataDictionary.Application.Tests
{
    public class DataDictionaryAppService_Tests : AbpDataDictionaryApplicationTestBase
    {
        private readonly IDataDictionaryAppService _dataDictionaryAppService;
        private readonly AbpDataDictionaryTestData _testData;

        public DataDictionaryAppService_Tests()
        {
            _testData = GetRequiredService<AbpDataDictionaryTestData>();
            _dataDictionaryAppService = GetRequiredService<IDataDictionaryAppService>();
        }

        [Fact]
        public async Task Should_Create_A_DataDictionary()
        {
            // Arrange
            var requestDto = new DataDictionaryCreateDto
            {
                Code = "XB",
                DisplayText = "性别",
                Description = "用于表示性别的数据字典。",
                IsStatic = true,
                Items = new List<DataDictionaryItemDto>
                {
                    new DataDictionaryItemDto
                    {
                        Code = "1",
                        DisplayText = "男"
                    },
                    new DataDictionaryItemDto
                    {
                        Code = "2",
                        DisplayText = "女"
                    }
                }
            };

            // Act
            var response = await _dataDictionaryAppService.CreateAsync(requestDto);

            // Assert
            response.ShouldNotBeNull();
            response.Code.ShouldNotBeNull("XB");

            UsingDbContext(db =>
            {
                var query = db.Dictionaries
                    .Include(x => x.Items)
                    .FirstOrDefault(x => x.Code == "XB");

                query.ShouldNotBeNull();
                query.Code.ShouldBe("XB");
                query.Items.Count.ShouldBe(2);
            });
        }

        [Fact]
        public async Task Should_Update_DataDictionary_DisplayText()
        {
            // Arrange
            var updateDto = new DataDictionaryUpdateDto
            {
                Description = "用于展示民族信息。",
                DisplayText = "民族(已修改)",
                Items = new List<DataDictionaryItemDto>
                {
                    new DataDictionaryItemDto
                    {
                        Code = "1",
                        DisplayText = "回族"
                    }
                }
            };

            // Act
            var response = await _dataDictionaryAppService.UpdateAsync(_testData.DataDictionary1, updateDto);

            // Assert
            response.ShouldNotBeNull();
            response.Description.ShouldNotBeEmpty();
            response.DisplayText.ShouldBe("民族(已修改)");
            
            UsingDbContext(db =>
            {
                var query = db.Dictionaries
                    .Include(x => x.Items)
                    .FirstOrDefault(x => x.Code == "MZ");
            
                query.ShouldNotBeNull();
                query.Items.Count.ShouldBe(1);
            });
        }

        [Fact]
        public async Task Should_Delete_DataDictionary()
        {
            // Arrange & Act
            await _dataDictionaryAppService.DeleteAsync(_testData.DataDictionary1);

            // Assert
            UsingDbContext(db =>
            {
                db.Dictionaries?.FirstOrDefault(x => x.Code == "MZ").ShouldBeNull();
                db.Dictionaries?.Count().ShouldBe(1);
            });
        }

        [Fact]
        public async Task Should_Return_A_DataDictionary()
        {
            // Act & Arrange
            var response = await _dataDictionaryAppService.GetAsync(_testData.DataDictionary1);

            // Assert
            response.ShouldNotBeNull();
            response.Code.ShouldBe("MZ");
            response.IsStatic.ShouldBe(true);
        }

        [Fact]
        public async Task Should_Return_A_DataDictionary_List()
        {
            // Arrange
            var requestDto = new PagedResultRequestDto
            {
                SkipCount = 0,
                MaxResultCount = 10
            };

            // Act
            var response = await _dataDictionaryAppService.GetListAsync(requestDto);

            // Assert
            response.ShouldNotBeNull();
            response.TotalCount.ShouldBe(2);
            response.Items.Any(x=>x.Code == "MZ").ShouldBe(true);
        }
    }
}