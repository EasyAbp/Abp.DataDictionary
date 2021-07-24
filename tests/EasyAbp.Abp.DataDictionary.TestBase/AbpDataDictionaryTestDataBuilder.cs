using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace EasyAbp.Abp.DataDictionary
{
    public class AbpDataDictionaryTestDataBuilder : ITransientDependency
    {
        private readonly IDataDictionaryRepository _dataDictionaryRepository;
        private readonly AbpDataDictionaryTestData _testData;

        public AbpDataDictionaryTestDataBuilder(IDataDictionaryRepository dataDictionaryRepository,
            AbpDataDictionaryTestData testData)
        {
            _dataDictionaryRepository = dataDictionaryRepository;
            _testData = testData;
        }

        public void Build()
        {
            AsyncHelper.RunSync(BuildAsync);
        }

        public async Task BuildAsync()
        {
            await _dataDictionaryRepository.InsertAsync(new DataDictionary(_testData.DataDictionary1, null, "MZ", "民族", null,
                new List<DataDictionaryItem>
                {
                    new DataDictionaryItem(_testData.DataDictionary1, null, "1", "汉族", null, true),
                    new DataDictionaryItem(_testData.DataDictionary1, null, "2", "羌族", null, true)
                }));

            await _dataDictionaryRepository.InsertAsync(new DataDictionary(_testData.DataDictionary2, null, "DJ", "等级", null,
                new List<DataDictionaryItem>
                {
                    new DataDictionaryItem(_testData.DataDictionary2, null, "1", "一级", null, true),
                    new DataDictionaryItem(_testData.DataDictionary2, null, "2", "二级", null, true)
                }));

            await _dataDictionaryRepository.InsertAsync(new DataDictionary(_testData.DataDictionary3, null, "XL", "学历", null,
                new List<DataDictionaryItem>
                {
                    new DataDictionaryItem(_testData.DataDictionary3, null, "1", "高中", null, true),
                    new DataDictionaryItem(_testData.DataDictionary3, null, "2", "大专", null, true),
                    new DataDictionaryItem(_testData.DataDictionary3, null, "3", "本科", null, true)
                }));
        }
    }
}