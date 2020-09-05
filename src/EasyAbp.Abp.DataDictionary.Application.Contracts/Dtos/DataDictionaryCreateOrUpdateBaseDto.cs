using System.Collections.Generic;

namespace EasyAbp.Abp.DataDictionary.Dtos
{
    public class DataDictionaryCreateOrUpdateBaseDto
    {
        public string DisplayText { get; set; }

        public string Description { get; set; }

        public List<DataDictionaryItemDto> Items { get; set; }
    }
}