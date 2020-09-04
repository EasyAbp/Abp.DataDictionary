using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DataDictionary.EntityFrameworkCore
{
    [ConnectionStringName(DataDictionaryDbProperties.ConnectionStringName)]
    public interface IDataDictionaryDbContext : IEfCoreDbContext
    {
        DbSet<DataDictionary> Dictionaries { get; set; }

        DbSet<DataDictionaryItem> DataDictionaryItems { get; set; }
    }
}