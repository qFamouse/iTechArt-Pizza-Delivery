using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.Size
{
    public class SizeUpdateRequest
    {
        [Required] [MinLength(3)] [MaxLength(255)]
        public string Name { get; set; }
        [Required] [Range(1, short.MaxValue)]
        public short Diameter { get; set; }
    }
}
