using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Entities
{
    public class Delivery : IEntity
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
