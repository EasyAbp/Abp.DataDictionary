using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DataDictionary.Sample
{
    public class StudentEntity : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public string Sex { get; set; }

        public string Level { get; set; }
    }
}