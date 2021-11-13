using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Requests.Pizza
{
    public class PizzaAddRequest
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
