using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.User;
using iTechArtPizzaDelivery.Core.Views;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Account
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> RegistrationAsync(UserRegistrationRequest request);
        Task<UserAuthorizationResult> AuthorizationAsync(UserAuthorizationRequest request);
    }
}
