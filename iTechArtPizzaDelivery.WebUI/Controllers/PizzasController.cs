using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Services;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzasService _pizzasService;

        public PizzasController(PizzasService pizzasService)
        {
            _pizzasService = pizzasService ??
                             throw new ArgumentNullException(nameof(pizzasService), "Service is null");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _pizzasService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _pizzasService.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] Pizza pizza)
        {
            return Ok(await _pizzasService.AddAsync(pizza));
        }
    }
}
