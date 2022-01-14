using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class PizzaSizeDetailView
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public float Weight { get; set; }

        public List<PizzaIngredientDetailView> PizzaIngredients { get; set; }
    }
}
