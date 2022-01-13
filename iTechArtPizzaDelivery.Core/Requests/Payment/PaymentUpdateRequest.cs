using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.Payment
{
    public class PaymentUpdateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
