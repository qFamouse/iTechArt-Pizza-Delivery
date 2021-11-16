using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Requests.OrderItem
{
    public class OrderItemAddFirstRequest
    {
        public int PizzaSizesId { get; set; }
        public short Quantity { get; set; }
    }
}
