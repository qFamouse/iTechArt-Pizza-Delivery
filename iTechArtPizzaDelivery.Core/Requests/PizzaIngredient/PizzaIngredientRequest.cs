using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.PizzaIngredient
{
    public class PizzaIngredientRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PizzaSizeId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int IngredientId { get; set; }
        [Required]
        [Range(0, float.MaxValue)]
        public float Weight { get; set; }
    }
}
