using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;
using iTechArtPizzaDelivery.Core.Services;
using iTechArtPizzaDelivery.WebUI.Views;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersItemsController : ControllerBase
    {
        private readonly IOrderItemService _ordersItemsService;
        private readonly IMapper _mapper;

        public OrdersItemsController(IOrderItemService ordersItemsService, IMapper mapper)
        {
            _ordersItemsService = ordersItemsService ?? // If pizzasSizesRepository is null
                                  throw new ArgumentNullException(nameof(ordersItemsService), "Service is null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByOrderIdAsync(int id)
        {
            var orderItems = await _ordersItemsService.GetByOrderIdAsync(id);
            var orderItemsView = _mapper.Map<List<OrderItem>, List<OrderItemDetailView>>(orderItems);
            return Ok(orderItemsView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] OrderItemUpdateRequest request)
        {
            var orderItems = await _ordersItemsService.UpdateByIdAsync(id, request);
            var orderItemsView = _mapper.Map<OrderItemDetailView>(orderItems);
            return Ok(orderItemsView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] OrderItemAddRequest request)
        {
            var orderItem = await _ordersItemsService.AddAsync(request);
            var orderItemView = _mapper.Map<OrderItemDetailView>(orderItem);
            return Ok(orderItemView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _ordersItemsService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
