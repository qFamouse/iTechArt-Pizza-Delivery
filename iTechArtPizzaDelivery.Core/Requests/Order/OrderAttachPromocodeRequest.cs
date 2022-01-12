using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.Order
{
    public class OrderAttachPromocodeRequest
    {
        public int OrderId { get; set; }
        public string Code { get; set; }
    }
}
