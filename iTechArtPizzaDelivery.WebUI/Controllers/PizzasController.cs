using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IPizzasService _pizzasService;

        public PizzasController(IPizzasService pizzasService)
        {
            _pizzasService = pizzasService ??
                             throw new ArgumentNullException(nameof(pizzasService), "Service is null");
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _pizzasService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _pizzasService.GetByIdAsync(id));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] PizzaAddRequest pAddRequest)
        {
            return Ok(await _pizzasService.AddAsync(pAddRequest));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pizzasService.DeleteAsync(id);
            return Ok();
        }
    }
}
