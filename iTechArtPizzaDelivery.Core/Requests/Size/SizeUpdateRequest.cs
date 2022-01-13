using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.Size
{
    public class SizeUpdateRequest
    {
        public string Name { get; set; }
        public short Diameter { get; set; }
    }
}
