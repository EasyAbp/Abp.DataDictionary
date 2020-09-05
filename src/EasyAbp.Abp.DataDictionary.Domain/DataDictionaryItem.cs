using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryItem : FullAuditedEntity, IMultiTenant
    {
        public Guid? TenantId { get; }

        public Guid DataDictionaryId { get; protected set; }

        public string Code { get; protected set; }

        public string DisplayText { get; protected set; }

        public string Description { get; set; }

        protected DataDictionaryItem()
        {
        }

        public DataDictionaryItem(Guid dataDictionaryId,
            Guid? tenantId,
            string code,
            string displayText)
        {
            DataDictionaryId = dataDictionaryId;
            TenantId = tenantId;
            Code = code;
            DisplayText = displayText;
        }

        public override object[] GetKeys()
        {
            return new object[] {DataDictionaryId, Code};
        }
    }
}