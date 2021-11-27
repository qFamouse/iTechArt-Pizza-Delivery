﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly IMapper _mapper;

        public UserController(UsersService usersService, IMapper mapper)
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
    }
}