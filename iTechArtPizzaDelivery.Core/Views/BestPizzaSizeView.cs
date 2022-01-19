using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Views
{
    public class BestPizzaSizeView
    {
        public PizzaSize PizzaSize { get; set; }
        public int NumberOfOrders { get; set; }
        public int PerMonth { get; set; }
    }
}