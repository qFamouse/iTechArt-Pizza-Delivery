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
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrdersItemsController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService ?? throw new ArgumentNullException(nameof(orderItemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var orderItems = await _orderItemService.GetAllAsync();
            var orderItemsView = _mapper.Map<List<OrderItem>, List<OrderItemDetailView>>(orderItems);
            return Ok(orderItemsView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] OrderItemUpdateRequest request)
        {
            var orderItems = await _orderItemService.UpdateByIdAsync(id, request);
            var orderItemsView = _mapper.Map<OrderItemDetailView>(orderItems);
            return Ok(orderItemsView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] OrderItemInsertRequest request)
        {
            var orderItem = await _orderItemService.AddAsync(request);
            var orderItemView = _mapper.Map<OrderItemDetailView>(orderItem);
            return Ok(orderItemView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _orderItemService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
