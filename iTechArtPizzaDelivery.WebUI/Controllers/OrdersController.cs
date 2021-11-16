using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Requests.Order;
using iTechArtPizzaDelivery.Domain.Services;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService ??
                            throw new ArgumentNullException(nameof(orderService), "Service is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _orderService.GetAllAsync());
        }

        [HttpPut("AddPromocode")]
        public async Task<ActionResult> AddPromocode(OrderAddPromocodeRequest request)
        {
            await _orderService.AddPromocode(request);
            return Ok();
        }
    }
}
