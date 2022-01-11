﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.Order;
using iTechArtPizzaDelivery.Domain.Services;
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
            _orderService = orderService ??
                            throw new ArgumentNullException(nameof(orderService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var order = await _orderService.GetAllAsync();
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
        [HttpPut("AttachPromocode")]
        public async Task<ActionResult> AttachPromocode(OrderAttachPromocodeRequest request)
        {
            await _orderService.AttachPromocode(request);
            return Ok();
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpPut("Process")]
        public async Task<ActionResult> Process()
        {
            await _orderService.ProcessOrder();
            return Ok();
        }
    }
}
