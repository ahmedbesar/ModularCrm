using AutoMapper;
using ModularCrm.Ordering.Orders.Dtos;
using ModularCrm.Ordering.Orders;

namespace ModularCrm.Ordering;

public class OrderingApplicationAutoMapperProfile : Profile
{
    public OrderingApplicationAutoMapperProfile()
    {
        CreateMap<Order, OrderDto>();
    }
}
