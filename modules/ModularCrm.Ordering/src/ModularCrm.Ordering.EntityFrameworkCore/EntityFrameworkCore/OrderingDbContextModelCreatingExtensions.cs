using Microsoft.EntityFrameworkCore;
using ModularCrm.Ordering.Orders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ModularCrm.Ordering.EntityFrameworkCore;

public static class OrderingDbContextModelCreatingExtensions
{
    public static void ConfigureOrdering(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        builder.Entity<Order>(b =>
        {
            b.ToTable("Orders");

            b.ConfigureByConvention();

            b.Property(q => q.CustomerName).IsRequired().HasMaxLength(120);
        });
    }
}
