using Microsoft.EntityFrameworkCore;

namespace EasyAbp.Abp.DataDictionary.EntityFrameworkCore
{
    public static class DataDictionaryDbContextModelBuilderExtensions
    {
        public static void ConfigureDataDictionary(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataDictionary>();
            modelBuilder.Entity<DataDictionaryItem>();
        }
    }
}