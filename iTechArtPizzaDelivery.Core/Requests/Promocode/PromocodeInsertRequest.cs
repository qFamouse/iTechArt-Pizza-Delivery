using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Requests.Promocode
{
    public class PromocodeInsertRequest
    {
        [Required] [MinLength(3)] [MaxLength(255)]
        public string Code { get; set; }
        [Required] [Range(1, double.MaxValue)]
        public double Discount { get; set; }
        [Required] [Range(1, short.MaxValue)]
        public short Measure { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
