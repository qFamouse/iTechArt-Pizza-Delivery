using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.Payment;
using iTechArtPizzaDelivery.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentsService paymentService, IMapper mapper)
        {
            _paymentService = paymentService ??
                              throw new ArgumentNullException(nameof(paymentService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _paymentService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync(PaymentAddRequest request)
        {
            return Ok(await _paymentService.AddAsync(request));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _paymentService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
