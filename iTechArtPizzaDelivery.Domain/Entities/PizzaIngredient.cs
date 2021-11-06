using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Entities
{
    public class PizzaIngredient
    {
        public int Id { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public Ingredient Ingredient { get; set; }
        public float Weight { get; set; }
    }
}
