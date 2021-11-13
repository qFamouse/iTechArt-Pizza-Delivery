using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class PizzaIngredientView
    {
        public int Id { get; set; }
        public int PizzaSizeId { get; set; }
        public int IngredientId { get; set; }
        public float Weight { get; set; }
    }
}
