using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.Abp.DataDictionary.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DataDictionary
{
    public class EfCoreDataDictionaryRepository : EfCoreRepository<IDataDictionaryDbContext, DataDictionary, Guid>, IDataDictionaryRepository
    {
        public EfCoreDataDictionaryRepository(IDbContextProvider<IDataDictionaryDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }


        public async Task<List<DataDictionary>> GetListAsync(int skipCount, int maxResultCount, CancellationToken cancellationToke = default)
        {
            return await (await WithDetailsAsync())
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToke));
        }

        public override async Task<IQueryable<DataDictionary>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).Include(x => x.Items);
        }
    }
}