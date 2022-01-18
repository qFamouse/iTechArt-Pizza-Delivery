using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class UserView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
