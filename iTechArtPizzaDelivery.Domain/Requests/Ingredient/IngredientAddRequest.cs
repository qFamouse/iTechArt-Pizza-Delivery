using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Requests.Ingredient
{
    public class IngredientAddRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
