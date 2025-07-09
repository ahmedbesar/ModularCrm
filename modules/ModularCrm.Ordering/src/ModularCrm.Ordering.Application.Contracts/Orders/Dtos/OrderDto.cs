using ModularCrm.Ordering.Orders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCrm.Ordering.Orders.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public Guid ProductId { get; set; }
        public OrderState State { get; set; }
    }
}
