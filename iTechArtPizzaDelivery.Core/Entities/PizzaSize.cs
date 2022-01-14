using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Entities
{
    public class PizzaSize : IEntity
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public float Weight { get; set; }

        public List<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
