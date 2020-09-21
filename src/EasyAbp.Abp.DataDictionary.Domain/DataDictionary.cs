using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionary : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        [NotNull]
        public virtual string Code { get; protected set; }

        [NotNull]
        public virtual string DisplayText { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }

        public virtual bool IsStatic { get; protected set; }

        public virtual List<DataDictionaryItem> Items { get; protected set; }
        protected DataDictionary()
        {
        }

        public DataDictionary(
            Guid id,
            Guid? tenantId,
            [NotNull] string code,
            [NotNull] string displayText,
            [CanBeNull] string description,
            List<DataDictionaryItem> items,
            bool isStatic = true) : base(id)
        {
            TenantId = tenantId;
            Code = code;
            IsStatic = isStatic;
            
            SetContent(displayText, description);
    
            Items = items;
        }

        public void AddOrUpdateItem(string code, string displayText, string description)
        {
            var existingItem = Items.SingleOrDefault(item => item.Code == code);
            
            if (existingItem == null)
            {
                Items.Add(new DataDictionaryItem(Id, TenantId, code, displayText, description));
            }
            else
            {
                existingItem.SetContent(displayText, description);
            }
        }
        
        public void SetContent(string displayText, string description)
        {
            DisplayText = displayText;
            Description = description;
        }
    }
}