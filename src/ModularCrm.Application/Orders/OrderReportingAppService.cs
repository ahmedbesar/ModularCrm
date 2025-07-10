using ModularCrm.Ordering.Orders;
using ModularCrm.Products.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ModularCrm.Orders
{
    public class OrderReportingAppService : ModularCrmAppService,IOrderReportingAppService
    {
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly IRepository<Product, Guid> _productRepository;

        public OrderReportingAppService(
            IRepository<Order, Guid> orderRepository,
            IRepository<Product, Guid> productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<List<OrderReportDto>>  GetLatestOrders()
        {
            var products = await _productRepository.GetQueryableAsync();
            var orders = await _orderRepository.GetQueryableAsync();
            var latest_Orders = from order in orders
                                   join product in products on order.ProductId equals product.Id
                                   orderby order.CreationTime ascending
                                   select new OrderReportDto
                                   {
                                    OrderId = order.Id,
                                    CustomerName= order.CustomerName,
                                    State=  order.State,
                                    ProductId= product.Id,
                                    ProductName= product.Name,
                                   };
            var result = latest_Orders.Take(10).ToList();
            return result;
        }
    }
}
