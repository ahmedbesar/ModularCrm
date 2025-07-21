using ModularCrm.Ordering.Orders.Dtos;
using ModularCrm.Ordering.Orders.Enums;
using ModularCrm.Ordering.Orders.Events;
using ModularCrm.Ordering.Orders.Interfaces;
using ModularCrm.Products.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace ModularCrm.Ordering.Orders
{
    public class OrderAppService : OrderingAppService, IOrderAppService
    {
        private readonly IProductIntegrationService _productIntegrationService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IDistributedEventBus _distributedEventBus;

        public OrderAppService(IRepository<Order, Guid> orderRepository
            , IProductIntegrationService productIntegrationService, IDistributedEventBus distributedEventBus)
        {
            _orderRepository = orderRepository;
            _productIntegrationService = productIntegrationService;
            _distributedEventBus = distributedEventBus;
        }

        public async Task<List<OrderDto>> GetListAsync()
        {
            var orders = await _orderRepository.GetListAsync();
            var ids = orders.Select(x => x.ProductId).Distinct().ToList();
            var products = (await _productIntegrationService
                .GetProductsByIdsAsync(ids))
            .ToDictionary(p => p.Id, p => p.Name);

            var orderDtos = ObjectMapper.Map<List<Order>, List<OrderDto>>(orders);

            orderDtos.ForEach(orderDto =>
            {
                orderDto.ProductName = products[orderDto.ProductId];
            });

            return orderDtos;

        }

        public async Task CreateAsync(OrderCreationDto input)
        {
            var order = new Order
            {
                CustomerName = input.CustomerName,
                ProductId = input.ProductId,
                State = OrderState.Placed
            };

            await _orderRepository.InsertAsync(order);
            await _distributedEventBus.PublishAsync(
                new OrderPlacedEto { CustomerName =order.CustomerName,ProductId=order.ProductId});
        }   
    }
}