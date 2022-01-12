using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int PizzaSizeId { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public double Price { get; set; }
        public short Quantity { get; set; }
        public double Weight { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
