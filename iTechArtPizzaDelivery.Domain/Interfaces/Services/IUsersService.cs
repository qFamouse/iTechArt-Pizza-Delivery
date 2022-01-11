using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.User;
using iTechArtPizzaDelivery.Domain.Views;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllAsync();
        Task<User> RegistrationAsync(UserRegistrationRequest request);
        Task<UserAuthorizationResult> AuthorizationAsync(UserAuthorizationRequest request);
    }
}
