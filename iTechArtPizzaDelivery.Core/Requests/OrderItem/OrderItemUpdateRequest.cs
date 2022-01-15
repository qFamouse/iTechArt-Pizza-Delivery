using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.OrderItem
{
    public class OrderItemUpdateRequest
    {
        [Required]
        [Range(1, short.MaxValue)]
        public short Quantity { get; set; }
    }
}
