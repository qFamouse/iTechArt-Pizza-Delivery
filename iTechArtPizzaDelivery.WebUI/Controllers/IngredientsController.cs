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
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;

        public IngredientsController(IngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService ??
                                  throw new ArgumentNullException(nameof(ingredientsService), "Service is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _ingredientsService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _ingredientsService.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] Ingredient ingredient)
        {
            return Ok(await _ingredientsService.AddAsync(ingredient));
        }
    }
}
