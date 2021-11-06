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
    public class PizzaIngredientsController : ControllerBase
    {
        private readonly PizzaIngredientsService _pizzaIngredientsService;

        public PizzaIngredientsController(PizzaIngredientsService pizzaIngredientsService)
        {
            _pizzaIngredientsService = pizzaIngredientsService ??
                                       throw new ArgumentNullException(nameof(pizzaIngredientsService), "Service is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _pizzaIngredientsService.GetAllAsync());
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] PizzaIngredient pizzaIngredient)
        {
            return Ok(await _pizzaIngredientsService.AddAsync(pizzaIngredient));
        }
    }
}
