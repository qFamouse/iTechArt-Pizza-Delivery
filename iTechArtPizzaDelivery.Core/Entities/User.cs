using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;

namespace iTechArtPizzaDelivery.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? Birthday { get; set; }
        public List<Order> Orders { get; set; }
    }
}
