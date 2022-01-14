using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Configurations;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Account;
using iTechArtPizzaDelivery.Core.Requests.User;
using iTechArtPizzaDelivery.Core.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace iTechArtPizzaDelivery.Core.Services.Account
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IdentityConfiguration _identityConfiguration;
        private readonly IIdentityService _identityService;

        public UserService(IUserRepository userRepository,
            UserManager<User> userManager, IMapper mapper, 
            IOptions<IdentityConfiguration> identityConfiguration,
            IIdentityService identityService)
        {
            _userRepository = userRepository ??
                              throw new ArgumentNullException(nameof(userRepository), "Interface is null");

            _userManager = userManager ??
                           throw new ArgumentNullException(nameof(userManager), "UserManager is null");

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper), "Mapper is null");

            _identityConfiguration = identityConfiguration.Value ??
                                     throw new ArgumentNullException(nameof(identityConfiguration), "Configuration is null");

            _identityService = identityService ??
                               throw new ArgumentNullException(nameof(identityService), "Interface is null");
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> RegistrationAsync(UserRegistrationRequest request)
        {
            var user = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, result.Errors.First().Description);
            }

            return user;
        }

        public async Task<UserAuthorizationResult> AuthorizationAsync(UserAuthorizationRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.NotFound, "User not found");
            }

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Incorrect password");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r)); // Claim all user roles

            List<Claim> authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.MobilePhone, user.Phone ?? ""), // fix null
                new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString()),
                new Claim(ClaimTypes.Email, user.UserName),
            };
            authClaims.AddRange(roleClaims); // Add user roles to main claims list

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identityConfiguration.SecurityKey));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(_identityConfiguration.ExpiresHours), // Move to constant
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserAuthorizationResult(encodedJwt, token.ValidTo);
        }
    }
}
