using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Services;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Requests.Delivery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient.DataClassification;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IDeliveriesService _deliveryService;
        private readonly IMapper _mapper;

        public DeliveriesController(IDeliveriesService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService ??
                               throw new ArgumentNullException(nameof(deliveryService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _deliveryService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _deliveryService.GetByIdAsync(id));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] DeliveryAddRequest request)
        {
            return Ok(await _deliveryService.AddAsync(request));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _deliveryService.DeleteByIdAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] DeliveryUpdateRequest request, int id)
        {
            return Ok(await _deliveryService.UpdateByIdAsync(id, request));
        }
    }
}
