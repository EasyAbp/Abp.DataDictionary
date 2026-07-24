using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DataDictionary.Sample
{
    public class StudentEntity : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; protected set; }

        public int Age { get; protected set; }

        public string Description { get; protected set; }

        public string Sex { get; protected set; }

        public string Level { get; protected set; }

        protected StudentEntity()
        {
        }

        public StudentEntity(Guid id, string name, int age, string description, string sex, string level) : base(id)
        {
            Name = name;
            Age = age;
            Description = description;
            Sex = sex;
            Level = level;
        }

        public void Update(int age, string description, string sex, string level)
        {
            Age = age;
            Description = description;
            Sex = sex;
            Level = level;
        }
    }
}
