using ModularCrm.Ordering.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModularCrm.Ordering.Orders.Interfaces
{
    public interface IOrderAppService : IApplicationService
    {
        Task<List<OrderDto>> GetListAsync();
        Task CreateAsync(OrderCreationDto input);
    }
}
