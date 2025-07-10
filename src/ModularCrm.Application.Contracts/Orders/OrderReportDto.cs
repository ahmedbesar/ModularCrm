using ModularCrm.Ordering.Orders.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCrm.Orders
{
    public class OrderReportDto
    {
        // Order data
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public OrderState State { get; set; }

        // Product data
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }

}
