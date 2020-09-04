using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.Abp.DataDictionary.EntityFrameworkCore
{
    [ConnectionStringName(DataDictionaryDbProperties.ConnectionStringName)]
    public class DataDictionaryDbContext : AbpDbContext<DataDictionaryDbContext>,IDataDictionaryDbContext
    {
        public DbSet<DataDictionary> Dictionaries { get; set; }
        
        public DbSet<DataDictionaryItem> DataDictionaryItems { get; set; }
        
        public DataDictionaryDbContext(DbContextOptions<DataDictionaryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ConfigureDataDictionary();
        }
    }
}