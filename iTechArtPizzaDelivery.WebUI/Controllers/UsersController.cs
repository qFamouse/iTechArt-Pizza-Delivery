using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Account;
using iTechArtPizzaDelivery.Core.Requests.User;
using iTechArtPizzaDelivery.Core.Services;
using iTechArtPizzaDelivery.WebUI.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService ??
                            throw new ArgumentNullException(nameof(usersService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var users = await _usersService.GetAllAsync();
            var usersView = _mapper.Map<List<User>, List<UserDetailView>> (users);
            return Ok(usersView);
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody] UserRegistrationRequest request)
        {
            return Ok(await _usersService.RegistrationAsync(request));
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] UserAuthorizationRequest request)
        {
            return Ok(await _usersService.AuthorizationAsync(request));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("Test")]
        public ActionResult Test()
        {
            return Ok("I test it: ");
        }
    }
}