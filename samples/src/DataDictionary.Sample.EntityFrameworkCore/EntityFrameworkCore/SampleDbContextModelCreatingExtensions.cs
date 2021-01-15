using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DataDictionary.Sample.EntityFrameworkCore
{
    public static class SampleDbContextModelCreatingExtensions
    {
        public static void ConfigureSample(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(SampleConsts.DbTablePrefix + "YourEntities", SampleConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<StudentEntity>(b =>
            {
                b.ToTable(SampleConsts.DbTablePrefix + "StudentEntities", SampleConsts.DbSchema);

                b.ConfigureFullAuditedAggregateRoot();

                b.Property(e => e.Name).HasMaxLength(64).IsRequired();
                b.Property(e => e.Description).HasMaxLength(1000);
                b.Property(e => e.Sex).HasMaxLength(8);
                b.Property(e => e.Level).HasMaxLength(8);
            });
        }
    }
}