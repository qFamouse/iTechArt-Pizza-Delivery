using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Fakes;
using Microsoft.AspNetCore.Mvc;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")] // Define route (for mapping to queries)
    [ApiController] // Define that is controller class 
    public class PizzasSizesController : ControllerBase
    {
        private readonly PizzasSizesService _pizzaSizesService;

        public PizzasSizesController(PizzasSizesService pizzaSizesService)
        {
            _pizzaSizesService = pizzaSizesService ?? // If pizzasSizesRepository is null
                                 throw new ArgumentNullException(nameof(pizzaSizesService), "Service is null");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _pizzaSizesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _pizzaSizesService.GetByIdAsync(id));
        }
    }
}
