using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.Abp.DataDictionary
{
    public interface IDataDictionaryRepository : IRepository<DataDictionary, Guid>
    {
        Task<List<DataDictionary>> GetListAsync(int skipCount, int maxResultCount, CancellationToken cancellationToke = default);
    }
}