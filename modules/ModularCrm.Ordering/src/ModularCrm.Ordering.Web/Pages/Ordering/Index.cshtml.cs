using Microsoft.AspNetCore.Mvc.RazorPages;
using ModularCrm.Ordering.Orders.Dtos;
using ModularCrm.Ordering.Orders.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModularCrm.Ordering.Web.Pages.Ordering;

public class IndexModel : PageModel
{
    public List<OrderDto> Orders { get; set; }

    private readonly IOrderAppService _orderAppService;

    public IndexModel(IOrderAppService orderAppService)
    {
        _orderAppService = orderAppService;
    }

    public async Task OnGetAsync()
    {
        Orders = await _orderAppService.GetListAsync();
    }
}
