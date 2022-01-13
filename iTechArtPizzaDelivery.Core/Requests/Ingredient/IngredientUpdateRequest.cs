using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.Ingredient
{
    public class IngredientUpdateRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
