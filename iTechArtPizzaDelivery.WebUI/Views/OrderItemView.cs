using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class OrderItemView
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaSizeId { get; set; }
        public double Price { get; set; }
        public short Quantity { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
