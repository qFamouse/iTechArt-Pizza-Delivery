using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient
{
    public class PizzaIngredientAddRequest
    {
        public int PizzaSizeId { get; set; }
        public int IngredientId { get; set; }
        public float Weight { get; set; }
    }
}
