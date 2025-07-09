using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModularCrm.Products.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<List<ProductDto>> GetListAsync();
        Task CreateAsync(ProductCreationDto input);
    }
}
