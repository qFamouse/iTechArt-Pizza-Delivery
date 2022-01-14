using System.Collections.Generic;
using System.Security.Claims;
using iTechArtPizzaDelivery.Core.Views;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Account
{
    public interface IIdentityService
    {
        ClaimsPrincipal ClaimsPrincipal { get; }
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
