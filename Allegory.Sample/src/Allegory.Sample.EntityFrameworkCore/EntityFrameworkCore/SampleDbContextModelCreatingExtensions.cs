using Allegory.Sample.Products;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Allegory.Sample.EntityFrameworkCore
{
    public static class SampleDbContextModelCreatingExtensions
    {
        public static void ConfigureSample(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Product>(b =>
            {
                b.ToTable(SampleConsts.DbTablePrefix + ProductConsts.TableName, SampleConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Code)
                          .IsRequired()
                          .HasMaxLength(ProductConsts.MaxCodeLength);

                b.HasIndex(x => x.Code);
            });
        }
    }
}
