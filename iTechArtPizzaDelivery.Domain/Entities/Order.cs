using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Entities
{
    public enum Status : short
    {
        Cancelled,          // 0 C
        InProgress,         // 1 N
        WaitingDelivery,    // 2 W
        Delivered           // 3 D
    }

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int? DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public int? PromocodeId { get; set; }
        public Promocode Promocode { get; set; }
        public short Status { get; set; } // 0 .. 3
        public double Price { get; set; }
        public string Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
