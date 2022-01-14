using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class OrderItemDetailView
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public PizzaSizeDetailView PizzaSize { get; set; }
        public double Price { get; set; }
        public short Quantity { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
