using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCrm.Ordering.Orders.Dtos
{
    public class OrderCreationDto
    {
        [Required]
        [StringLength(150)]
        public string CustomerName { get; set; }

        [Required]
        public Guid ProductId { get; set; }
    }
}
