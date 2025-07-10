using AutoMapper;
using ModularCrm.Ordering.Orders.Dtos;
using ModularCrm.Ordering.Orders;
using Volo.Abp.AutoMapper;

namespace ModularCrm.Ordering;

public class OrderingApplicationAutoMapperProfile : Profile
{
    public OrderingApplicationAutoMapperProfile()
    {
        CreateMap<Order, OrderDto>().Ignore(x=>x.ProductName);
    }
}
