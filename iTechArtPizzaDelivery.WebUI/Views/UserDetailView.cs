using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.WebUI.Views
{
    public class UserDetailView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public List<OrderView> Orders { get; set; }
    }
}
