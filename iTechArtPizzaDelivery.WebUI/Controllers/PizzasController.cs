using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Requests.Pizza;
using iTechArtPizzaDelivery.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;
        private readonly IMapper _mapper;

        public PizzasController(IPizzaService pizzaService, IMapper mapper)
        {
            _pizzaService = pizzaService ?? throw new ArgumentNullException(nameof(pizzaService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _pizzaService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _pizzaService.GetByIdAsync(id));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _pizzaService.DeleteByIdAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] PizzaInsertRequest request)
        {
            return Ok(await _pizzaService.AddAsync(request));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] PizzaUpdateRequest request)
        {
            return Ok(await _pizzaService.UpdateByIdAsync(id, request));
        }

        [HttpPost("images")]
        public async Task<ActionResult> UploadImageAsync(IFormFile file)
        {
            return Ok(await _pizzaService.UploadImageAsync(file));
        }
    }
}