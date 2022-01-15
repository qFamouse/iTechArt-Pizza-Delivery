using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.OrderItem
{
    public class OrderItemInsertRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PizzaSizesId { get; set; }
        [Required]
        [Range(1, short.MaxValue)]
        public short Quantity { get; set; }
    }
}
