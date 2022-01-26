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
        private readonly IMailerService _mailerService;

        public UserService(IUserRepository userRepository, UserManager<User> userManager, IMapper mapper,
            IOptions<IdentityConfiguration> identityConfiguration, IIdentityService identityService, IMailerService mailerService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _identityConfiguration =
                identityConfiguration.Value ?? throw new ArgumentNullException(nameof(identityConfiguration));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mailerService = mailerService ?? throw new ArgumentNullException(nameof(mailerService));
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<List<User>> GetAllByPageAsync(int pageNumber)
        {
            return _userRepository.GetAllByPageAsync(pageNumber);
        }

        public async Task<User> RegistrationAsync(UserRegistrationRequest request)
        {
            var user = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, result.Errors.First().Description);
            }

            await _userManager.AddToRoleAsync(user, _identityConfiguration.UserRole);

            SendMainAboutSuccessfulRegistration(request.Email);

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
                new Claim(ClaimTypes.MobilePhone, user.Phone ?? ""),
                new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString()),
                new Claim(ClaimTypes.Email, user.UserName),
            };
            authClaims.AddRange(roleClaims); // Add user roles to main claims list

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_identityConfiguration.SecurityKey));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(_identityConfiguration.ExpiresHours),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserAuthorizationResult(encodedJwt, token.ValidTo);
        }

        public async Task DeleteAsync()
        {
            var user = await _userManager.GetUserAsync(_identityService.ClaimsPrincipal);
            await _userManager.DeleteAsync(user);
            SendMainAboutAccountDeletion(user.Email);
        }

        private void SendMainAboutSuccessfulRegistration(string email)
        {
            _mailerService.SendMail(new MailView()
            {
                Subject = "Successful registration :)",
                Html = "This <i>message</i> was sent from <strong>ASP .NET CORE</strong> server.",
                Text = "Thank you for registering",
                To = new List<string>{email}
            });
        }

        private void SendMainAboutAccountDeletion(string email)
        {
            _mailerService.SendMail(new MailView()
            {
                Subject = "Your account has been deleted :(",
                Html = "This <i>message</i> was sent from <strong>ASP .NET CORE</strong> server.",
                Text = "Come back again",
                To = new List<string> { email }
            });
        }
    }
}
