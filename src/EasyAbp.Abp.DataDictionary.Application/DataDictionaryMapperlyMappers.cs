using EasyAbp.Abp.DataDictionary.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Abp.DataDictionary
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class DataDictionaryToDataDictionaryDtoMapper : MapperBase<DataDictionary, DataDictionaryDto>
    {
        public override partial DataDictionaryDto Map(DataDictionary source);
        public override partial void Map(DataDictionary source, DataDictionaryDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class DataDictionaryItemToDataDictionaryItemDtoMapper : MapperBase<DataDictionaryItem, DataDictionaryItemDto>
    {
        public override partial DataDictionaryItemDto Map(DataDictionaryItem source);
        public override partial void Map(DataDictionaryItem source, DataDictionaryItemDto destination);
    }
}
