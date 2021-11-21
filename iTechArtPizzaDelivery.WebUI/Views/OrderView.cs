using System;
using System.Collections.Generic;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class OrderView
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
        public List<OrderItemView> OrderItems { get; set; }
    }
}
