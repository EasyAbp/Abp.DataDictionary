using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.Abp.DataDictionary
{
    public class DataDictionary : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; }

        public string Code { get; protected set; }

        public string DisplayText { get; protected set; }

        public bool IsSystem { get; protected set; }

        public ICollection<DataDictionaryItem> Items { get; set; }

        public string Description { get; set; }

        protected DataDictionary()
        {
        }

        public DataDictionary(Guid id,
            Guid? tenantId,
            string code,
            string displayText,
            bool isSystem = true)
        {
            Id = id;
            TenantId = tenantId;
            Code = code;
            DisplayText = displayText;
            IsSystem = isSystem;
            Items = new Collection<DataDictionaryItem>();
        }

        public void AddItem(string itemCode,
            string itemDisplayText,
            string itemDescription)
        {
            if (Items == null)
            {
                return;
            }

            if (Items.Any(it => it.Code == itemCode))
            {
                return;
            }

            Items.Add(new DataDictionaryItem(Id, TenantId, itemCode, itemDisplayText)
            {
                Description = itemDescription
            });
        }

        public void RemoveAll() => Items.Clear();

        public void Update(string displayText)
        {
            DisplayText = displayText;
        }
    }
}