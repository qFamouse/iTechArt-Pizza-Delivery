using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.User;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.WebUI.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(UsersService usersService, IMapper mapper)
        {
            _usersService = usersService ??
                            throw new ArgumentNullException(nameof(usersService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var users = await _usersService.GetAllAsync();
            var usersView = _mapper.Map<List<User>, List<UserDetailView>> (users);
            return Ok(usersView);
        }

        [HttpPost("/Register")]
        public async Task<ActionResult> RegisterAsync(UserRegistrationRequest request)
        {
            return Ok(await _usersService.RegisterAsync(request));
        }

        [HttpPost("/Login")]
        public async Task<ActionResult> LoginAsync(UserAuthorizationRequest request)
        {
            return Ok(await _usersService.LoginAsync(request));
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("Test")]
        public ActionResult Test()
        {
            return Ok("I test it: ");
        }
    }
}