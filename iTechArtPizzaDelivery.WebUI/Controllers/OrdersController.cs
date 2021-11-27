using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Order;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(OrderService orderService, IMapper mapper)
        {
            _orderService = orderService ??
                            throw new ArgumentNullException(nameof(orderService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _orderService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDetailByIdAsync(int id)
        {
            var order = await _orderService.GetDetailByIdAsync(id);
            var orderView = _mapper.Map<OrderDetailView>(order);
            return Ok(orderView);
        }

        [HttpPut("AttachPromocode")]
        public async Task<ActionResult> AttachPromocode(OrderAttachPromocodeRequest request)
        {
            await _orderService.AttachPromocode(request);
            return Ok();
        }

        [HttpPut("Process")]
        public async Task<ActionResult> Process()
        {
            await _orderService.ProcessOrder();
            return Ok();
        }
    }
}
