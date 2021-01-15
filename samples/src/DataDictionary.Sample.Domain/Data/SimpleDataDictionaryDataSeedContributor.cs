using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Dict = EasyAbp.Abp.DataDictionary.DataDictionary;

namespace DataDictionary.Sample.Data
{
    public class SimpleDataDictionaryDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IDataDictionaryRepository _dataDictionaryRepository;
        private readonly IGuidGenerator _guidGenerator;

        public SimpleDataDictionaryDataSeedContributor(IDataDictionaryRepository dataDictionaryRepository, IGuidGenerator guidGenerator)
        {
            _dataDictionaryRepository = dataDictionaryRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _dataDictionaryRepository.GetCountAsync() == 0)
            {
                var dict1 = new Dict(_guidGenerator.Create(),
                    context.TenantId,
                    "Sex",
                    "性别",
                    "性别信息。",
                    new List<DataDictionaryItem>());
                dict1.AddOrUpdateItem("1","男","男性");
                dict1.AddOrUpdateItem("2","女","女性");
                dict1.AddOrUpdateItem("3","未知","未知性别");

                var dict2 = new Dict(_guidGenerator.Create(),
                    context.TenantId,
                    "Level",
                    "等级",
                    "等级信息",
                    new List<DataDictionaryItem>());
                dict2.AddOrUpdateItem("1","一级","一级");
                dict2.AddOrUpdateItem("2","二级","二级");
                dict2.AddOrUpdateItem("3","三级","三级");
                dict2.AddOrUpdateItem("4","四级","四级");

                await _dataDictionaryRepository.InsertAsync(dict1);
                await _dataDictionaryRepository.InsertAsync(dict2);
            }
        }
    }
}