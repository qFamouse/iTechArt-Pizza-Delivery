using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Exceptions;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UsersService(IUserRepository userRepository, UserManager<User> userManager, IMapper mapper)
        {
            _userRepository = userRepository ??
                              throw new ArgumentNullException(nameof(userRepository), "Interface is null");

            _userManager = userManager ??
                           throw new ArgumentNullException(nameof(userManager), "UserManager is null");

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> RegisterAsync(UserRegistrationRequest request)
        {
            var user = _mapper.Map<User>(request);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new HttpStatusCodeException(404, result.Errors.First().Description);
            }

            return user;
        }

        public async Task<string> LoginAsync(UserAuthorizationRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null)
            {
                // throw new No such user; // Coming Soon (Exceptions)
            }

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                // throw new Wrong password (or email, for security) // Coming Soon (Exceptions)
            }

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r)); // Claim all user roles

            List<Claim> authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString()),
                new Claim(ClaimTypes.Email, user.UserName),
            };
            authClaims.AddRange(roleClaims); // Add user roles to main claims list

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aksdokjafbkjasbfjabojsfbda"));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1), // Move to constant
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            var response = new
            {
                token = encodedJwt,
                expiration = token.ValidTo
            };

            return JsonSerializer.Serialize(response);
        }
    }
}
