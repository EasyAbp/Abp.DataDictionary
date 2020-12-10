using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DataDictionary.Dtos
{
    public class DataDictionaryDto : FullAuditedEntityDto<Guid>
    {
        public DataDictionaryDto()
        {
            this.Items = new List<DataDictionaryItemDto>();
        }

        public string Code { get; set; }

        public string DisplayText { get; set; }

        public bool IsStatic { get; set; }

        public string Description { get; set; }

        public List<DataDictionaryItemDto> Items { get; set; }
    }
}