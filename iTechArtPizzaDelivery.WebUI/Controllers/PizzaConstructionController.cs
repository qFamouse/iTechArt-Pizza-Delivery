﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Construction;
using iTechArtPizzaDelivery.Core.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Core.Requests.PizzaSize;
using iTechArtPizzaDelivery.Core.Services;
using iTechArtPizzaDelivery.WebUI.Views;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaConstructionController : ControllerBase
    {
        private readonly IPizzaConstructionService _pizzaConstructionService;
        private readonly IMapper _mapper;

        public PizzaConstructionController(IPizzaConstructionService pizzaConstructionService, IMapper mapper)
        {
            _pizzaConstructionService = pizzaConstructionService ??
                                        throw new ArgumentNullException(nameof(pizzaConstructionService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var pizzasSizes = await _pizzaConstructionService.GetAllAsync();
            var pizzasSizesView = _mapper.Map<List<PizzaSize>, List<PizzaSizeView>>(pizzasSizes);
            return Ok(pizzasSizesView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var pizzaSize = await _pizzaConstructionService.GetDetailByIdAsync(id);
            var pizzaSizeView = _mapper.Map<PizzaSizeDetailView>(pizzaSize);
            return Ok(pizzaSizeView);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] PizzaSizeInsertRequest request)
        {
            var pizzaSize = await _pizzaConstructionService.InsertAsync(request);
            var pizzaSizeView = _mapper.Map<PizzaSizeDetailView>(pizzaSize);
            return Ok(pizzaSizeView);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pizzaConstructionService.DeleteByIdAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpPost("ingredient")]
        public async Task<ActionResult> InsertIngredientAsync([FromBody] PizzaIngredientRequest request)
        {
            var updatedPizzaSize = await _pizzaConstructionService.InsertIngredientAsync(request);
            var updatedPizzaSizeView = _mapper.Map<PizzaSizeDetailView>(updatedPizzaSize);
            return Ok(updatedPizzaSizeView);
        }
    }
}
