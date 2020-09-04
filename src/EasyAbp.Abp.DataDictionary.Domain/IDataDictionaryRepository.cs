using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryRepository : IRepository<DataDictionary, Guid>
    {
    }
}