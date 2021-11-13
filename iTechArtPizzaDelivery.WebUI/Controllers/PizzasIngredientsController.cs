using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasIngredientsController : ControllerBase
    {
        private readonly PizzasIngredientsService _pizzaIngredientsService;
        private readonly IMapper _mapper;

        public PizzasIngredientsController(PizzasIngredientsService pizzaIngredientsService, IMapper mapper)
        {
            _pizzaIngredientsService = pizzaIngredientsService ??
                                       throw new ArgumentNullException(nameof(pizzaIngredientsService), "Service is null");

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var pizzaIngredient = await _pizzaIngredientsService.GetAllAsync();
            var pizzaIngredientView = _mapper.Map<List<PizzaIngredient>, List<PizzaIngredientView>>(pizzaIngredient);
            return Ok(pizzaIngredientView);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] PizzaIngredientAddRequest piAddRequest)
        {
            return Ok(await _pizzaIngredientsService.AddAsync(piAddRequest));
        }
    }
}
