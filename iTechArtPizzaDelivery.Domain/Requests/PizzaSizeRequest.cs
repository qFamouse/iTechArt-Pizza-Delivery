using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Requests
{
    public class PizzaSizeAddRequest
    {
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public double Price { get; set; }
        public float Weight { get; set; }
    }
}
