using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModularCrm.Orders
{
    public interface IOrderReportingAppService : IApplicationService
    {
        Task<List<OrderReportDto>> GetLatestOrders();
    }
}
