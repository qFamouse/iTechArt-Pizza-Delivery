using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.OrderItem;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersItemsController : ControllerBase
    {
        private readonly OrdersItemsService _ordersItemsService;
        private readonly IMapper _mapper;

        public OrdersItemsController(OrdersItemsService ordersItemsService, IMapper mapper)
        {
            _ordersItemsService = ordersItemsService ?? // If pizzasSizesRepository is null
                                  throw new ArgumentNullException(nameof(ordersItemsService), "Service is null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        //public Task<List<OrderItem>> GetByOrderIdAsync(int id);
        //public Task<OrderItem> EditByIdAsync(int id);
        //public Task DeleteAsync(int id);
        //public Task<OrderItem> AddAsync(OrderItemAddRequest oiAddRequest);

        [HttpGet("Order/{id}")]
        public async Task<ActionResult> GetItemsByOrderIdAsync(int id)
        {
            var orderItems = await _ordersItemsService.GetItemsByOrderIdAsync(id);
            var orderItemsView = _mapper.Map<List<OrderItem>, List<OrderItemDetailView>>(orderItems);
            return Ok(orderItemsView);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> EditItemByIdAsync(OrderItemEditRequest request)
        {
            var orderItems = await _ordersItemsService.EditItemByIdAsync(request);
            var orderItemsView = _mapper.Map<OrderItem, OrderItemDetailView>(orderItems);
            return Ok(orderItemsView);
        }

    }
}
