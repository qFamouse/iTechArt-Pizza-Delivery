using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Requests.Order
{
    public class OrderAddPromocodeRequest
    {
        public int OrderId { get; set; }
        public string Code { get; set; }
    }
}
