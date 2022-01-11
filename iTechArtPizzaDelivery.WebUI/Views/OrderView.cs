using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class OrderView
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? PaymentId { get; set; }
        public int? DeliveryId { get; set; }
        public int? PromocodeId { get; set; }
        public short Status { get; set; } // 0 .. 3
        public double Price { get; set; }
        public string Comment { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
