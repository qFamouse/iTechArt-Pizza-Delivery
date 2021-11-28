using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Domain.Requests.User
{
    public class UserAuthorizationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
