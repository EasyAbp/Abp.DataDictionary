using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionaryItem : AuditedEntity, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid DataDictionaryId { get; protected set; }

        [NotNull]
        public virtual string Code { get; protected set; }

        [NotNull]
        public virtual string DisplayText { get; protected set; }

        [CanBeNull]
        public virtual string Description { get; protected set; }
        
        public virtual bool IsStatic { get; protected set; }

        protected DataDictionaryItem()
        {
        }

        public DataDictionaryItem(
            Guid dataDictionaryId,
            Guid? tenantId,
            [NotNull] string code,
            [NotNull] string displayText,
            [CanBeNull] string description,
            bool isStatic)
        {
            DataDictionaryId = dataDictionaryId;
            TenantId = tenantId;
            Code = code;
            IsStatic = isStatic;
            
            SetContent(displayText, description);
        }

        public override object[] GetKeys()
        {
            return new object[] {DataDictionaryId, Code};
        }

        public void SetContent(string displayText, string description)
        {
            DisplayText = displayText;
            Description = description;
        }
    }
}