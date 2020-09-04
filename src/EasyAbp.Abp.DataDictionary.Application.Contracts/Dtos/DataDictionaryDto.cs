using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DataDictionary.Dtos
{
    public class DataDictionaryDto : FullAuditedEntityDto<Guid>
    {
        public string Code { get; set; }

        public string DisplayText { get; set; }

        public bool IsSystem { get; set; }
    }
}