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
using iTechArtPizzaDelivery.Core.Requests.Promocode;
using iTechArtPizzaDelivery.Core.Services;
using iTechArtPizzaDelivery.WebUI.Views;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync([FromQuery(Name = "page")] int page)
        {
            var order = page > 0 ? await _orderService.GetAllByPageAsync(page) : await _orderService.GetAllAsync();
            var orderView = _mapper.Map<List<OrderView>>(order);
            return Ok(orderView);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDetailByIdAsync(int id)
        {
            var order = await _orderService.GetDetailByIdAsync(id);
            var orderView = _mapper.Map<OrderDetailView>(order);
            return Ok(orderView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet("my_order")]
        public async Task<ActionResult> GetMyOrder()
        {
            var order = await _orderService.GetDetailByUserAsync();
            var orderView = _mapper.Map<OrderDetailView>(order);
            return Ok(orderView);
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPatch("attach_promocode")]
        public async Task<ActionResult> AttachPromocodeAsync(string promocode)
        {
            await _orderService.AttachPromocodeAsync(promocode);
            return Ok();
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPatch("attach_payment")]
        public async Task<ActionResult> AttachPaymentAsync(int paymentId)
        {
            await _orderService.AttachPaymentAsync(paymentId);
            return Ok();
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPatch("attach_delivery")]
        public async Task<ActionResult> AttachDeliveryAsync(int deliveryId)
        {
            await _orderService.AttachDeliveryAsync(deliveryId);
            return Ok();
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPut("processing")]
        public async Task<ActionResult> Process()
        {
            await _orderService.ProcessOrderAsync();
            return Ok();
        }
    }
}
