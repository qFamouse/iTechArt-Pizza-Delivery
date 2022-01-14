using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Requests.Ingredient;
using iTechArtPizzaDelivery.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientsController(IIngredientService ingredientService, IMapper mapper)
        {
            _ingredientService = ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _ingredientService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _ingredientService.GetByIdAsync(id));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] IngredientInsertRequest iAddRequest)
        {
            return Ok(await _ingredientService.AddAsync(iAddRequest));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _ingredientService.DeleteByIdAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] IngredientUpdateRequest request, int id)
        {
            return Ok(await _ingredientService.UpdateByIdAsync(id, request));
        }
    }
}
