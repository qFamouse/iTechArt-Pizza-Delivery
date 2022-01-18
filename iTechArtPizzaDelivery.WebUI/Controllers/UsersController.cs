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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery(Name = "page")] int page)
        {
            var users = page > 0 ? await _userService.GetAllByPageAsync(page) : await _userService.GetAllAsync();
            var usersView = _mapper.Map<List<User>, List<UserView>> (users);
            return Ok(usersView);
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromBody] UserRegistrationRequest request)
        {
            return Ok(await _userService.RegistrationAsync(request));
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] UserAuthorizationRequest request)
        {
            return Ok(await _userService.AuthorizationAsync(request));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync()
        {
            await _userService.DeleteAsync();
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("Test")]
        public ActionResult Test()
        {
            return Ok("I test it: ");
        }
    }
}