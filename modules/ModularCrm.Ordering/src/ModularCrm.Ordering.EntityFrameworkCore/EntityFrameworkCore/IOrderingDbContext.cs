using Microsoft.EntityFrameworkCore;
using ModularCrm.Ordering.Orders;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ModularCrm.Ordering.EntityFrameworkCore;

[ConnectionStringName(OrderingDbProperties.ConnectionStringName)]
public interface IOrderingDbContext : IEfCoreDbContext
{
      DbSet<Order> Orders { get; set; }
    
}
