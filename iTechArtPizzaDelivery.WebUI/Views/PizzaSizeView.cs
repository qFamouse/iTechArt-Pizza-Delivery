using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class PizzaSizeView
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public double Price { get; set; }
        public float Weight { get; set; }
    }
}