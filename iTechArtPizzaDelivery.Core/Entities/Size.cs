using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Entities
{
    public class Size : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Diameter { get; set; }
    }
}
