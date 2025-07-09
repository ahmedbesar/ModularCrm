using AutoMapper;
using ModularCrm.Products.Products;
using ModularCrm.Products;

namespace ModularCrm;

public class ModularCrmApplicationAutoMapperProfile : Profile
{
    public ModularCrmApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
