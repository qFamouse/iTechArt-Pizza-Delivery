using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasCartController : ControllerBase
    {
        private readonly PizzasCartService _pizzasCartService;
        private readonly IMapper _mapper;

        public PizzasCartController(PizzasCartService pizzasCartService, IMapper mapper)
        {
            _pizzasCartService = pizzasCartService ??
                                 throw new ArgumentNullException(nameof(pizzasCartService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var pizzasSizes = await _pizzasCartService.GetAllAsync();
            var pizzasSizesView = _mapper.Map<List<PizzaSize>, List<PizzaSizesView>>(pizzasSizes);
            return Ok(pizzasSizesView);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var pizzaSize = await _pizzasCartService.GetByIdAsync(id);
            var pizzaSizeView = _mapper.Map<PizzaSizesView>(pizzaSize);
            return Ok(pizzaSizeView);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] PizzaSizeAddRequest request)
        {
            return Ok(await _pizzasCartService.AddAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pizzasCartService.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPost("BindIngredient")]
        public async Task<ActionResult> BindIngredient([FromBody] PizzaIngredientBindRequest request)
        {
            return Ok(await _pizzasCartService.BindIngredient(request));
        }
    }
}
