using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Entities
{
    public class PizzaIngredient
    {
        public int Id { get; set; }
        public float Weight { get; set; }

        public int PizzaSizeId { get; set; }
        public PizzaSize PizzaSize { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
