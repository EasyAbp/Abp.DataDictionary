using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryItem : FullAuditedEntity<Guid>
    {
        public string Code { get; protected set; }

        public string DisplayText { get; protected set; }

        protected DataDictionaryItem()
        {
        }
    }
}