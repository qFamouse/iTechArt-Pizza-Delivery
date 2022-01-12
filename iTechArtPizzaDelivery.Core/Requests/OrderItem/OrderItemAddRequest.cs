using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.OrderItem
{
    public class OrderItemAddRequest
    {
        public int PizzaSizesId { get; set; }
        public short Quantity { get; set; }
    }
}
