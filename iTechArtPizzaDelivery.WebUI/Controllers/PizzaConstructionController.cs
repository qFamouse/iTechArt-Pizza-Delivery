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
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaConstructionController : ControllerBase
    {
        private readonly PizzaConstructionService _pizzaConstructionService;
        private readonly IMapper _mapper;

        public PizzaConstructionController(PizzaConstructionService pizzaConstructionService, IMapper mapper)
        {
            _pizzaConstructionService = pizzaConstructionService ??
                                 throw new ArgumentNullException(nameof(pizzaConstructionService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var pizzasSizes = await _pizzaConstructionService.GetAllAsync();
            var pizzasSizesView = _mapper.Map<List<PizzaSize>, List<PizzaSizesView>>(pizzasSizes);
            return Ok(pizzasSizesView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var pizzaSize = await _pizzaConstructionService.GetByIdAsync(id);
            var pizzaSizeView = _mapper.Map<PizzaSizesView>(pizzaSize);
            return Ok(pizzaSizeView);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] PizzaSizeAddRequest request)
        {
            return Ok(await _pizzaConstructionService.AddAsync(request));
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pizzaConstructionService.DeleteByIdAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpPost("AddIngredient")]
        public async Task<ActionResult> BindIngredient([FromBody] PizzaIngredientBindRequest request)
        {
            var updatedPizzaSize = await _pizzaConstructionService.AddIngredient(request);
            var updatedPizzaSizeView = _mapper.Map<PizzaSizesView>(updatedPizzaSize);
            return Ok(updatedPizzaSizeView);
        }
    }
}
