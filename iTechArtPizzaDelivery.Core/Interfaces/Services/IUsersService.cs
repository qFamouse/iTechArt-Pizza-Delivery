using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.User;
using iTechArtPizzaDelivery.Core.Views;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllAsync();
        Task<User> RegistrationAsync(UserRegistrationRequest request);
        Task<UserAuthorizationResult> AuthorizationAsync(UserAuthorizationRequest request);
    }
}
