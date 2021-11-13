using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        // User
        // Payment
        // Delivery
        public Promocode Promocode { get; set; }
        public short Status { get; set; } // 0 .. 3
        public double Price { get; set; }
        public string Comment { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
