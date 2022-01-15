using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Requests.PizzaSize
{
    public class PizzaSizeInsertRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PizzaId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int SizeId { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Range(0, float.MaxValue)]
        public float Weight { get; set; }
    }
}
