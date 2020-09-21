using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.Abp.DataDictionary.EntityFrameworkCore
{
    public static class DataDictionaryDbContextModelBuilderExtensions
    {
        public static void ConfigureDataDictionary(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataDictionary>(b =>
            {
                b.ToTable(DataDictionaryDbProperties.DbTablePrefix + "DataDictionaries", DataDictionaryDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Code).IsRequired().HasMaxLength(DataDictionaryConsts.MaxCodeLength);
                b.Property(x => x.DisplayText).IsRequired().HasMaxLength(DataDictionaryConsts.MaxDisplayTextLength);
                b.Property(x => x.Description).HasMaxLength(DataDictionaryConsts.MaxDescriptionLength);
                b.Property(x => x.IsStatic).IsRequired();

                b.HasMany(x => x.Items).WithOne().HasForeignKey(x => x.DataDictionaryId).IsRequired();
                b.HasIndex(x => x.Code);
            });

            modelBuilder.Entity<DataDictionaryItem>(b =>
            {
                b.ToTable(DataDictionaryDbProperties.DbTablePrefix + "DataDictionaryItems", DataDictionaryDbProperties.DbSchema);
                b.ConfigureByConvention();

                b.Property(x => x.Code).IsRequired().HasMaxLength(DataDictionaryItemConsts.MaxCodeLength);
                b.Property(x => x.DisplayText).IsRequired().HasMaxLength(DataDictionaryItemConsts.MaxDisplayTextLength);
                b.Property(x => x.Description).HasMaxLength(DataDictionaryItemConsts.MaxDescriptionLength);

                b.HasIndex(x => new {x.Code, x.DataDictionaryId});
                b.HasKey(x => new {x.Code, x.DataDictionaryId});
            });
        }
    }
}