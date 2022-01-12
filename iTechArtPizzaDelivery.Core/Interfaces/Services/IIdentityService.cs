using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Views;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IIdentityService
    {
        int Id { get; }
        string Name { get; }
        string Phone { get; }
        string Birthday { get; }
        string Email { get; }
        List<string> Roles { get; }

        UserView User { get; }

        bool IsAuthenticated { get; }
        bool IsInRole(string role);
    }
}
