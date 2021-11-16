using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class OrderItemsView
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public PizzaSizesView PizzaSize { get; set; }
        public double Price { get; set; }
        public short Quantity { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
