using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class PizzaIngredientDetailView
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public float Weight { get; set; }
    }
}
