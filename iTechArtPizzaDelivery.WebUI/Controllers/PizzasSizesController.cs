using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests;
using iTechArtPizzaDelivery.Domain.Services;
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
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _pizzaSizesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _pizzaSizesService.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] PizzaSizeAddRequest pizzaSizeAddRequest)
        {
            return Ok(await _pizzaSizesService.AddAsync(pizzaSizeAddRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pizzaSizesService.DeleteAsync(id);
            return Ok();
        }
    }
}
