using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.WebUI.Views;
using Microsoft.AspNetCore.Mvc;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")] // Define route (for mapping to queries)
    [ApiController] // Define that is controller class 
    public class PizzasSizesController : ControllerBase
    {
        private readonly PizzasSizesService _pizzaSizesService;
        private readonly IMapper _mapper;

        public PizzasSizesController(PizzasSizesService pizzaSizesService, IMapper mapper)
        {
            _pizzaSizesService = pizzaSizesService ?? // If pizzasSizesRepository is null
                                 throw new ArgumentNullException(nameof(pizzaSizesService), "Service is null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _pizzaSizesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDetailByIdAsync(int id)
        {
            var pizzaSize = await _pizzaSizesService.GetDetailByIdAsync(id);
            var pizzaSizeView = _mapper.Map<PizzaSizesView>(pizzaSize);
            return Ok(pizzaSizeView);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] PizzaSizeAddRequest psAddRequest)
        {
            return Ok(await _pizzaSizesService.AddAsync(psAddRequest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pizzaSizesService.DeleteAsync(id);
            return Ok();
        }
    }
}
