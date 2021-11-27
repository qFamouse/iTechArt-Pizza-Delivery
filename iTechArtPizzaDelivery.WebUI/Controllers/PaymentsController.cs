using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Requests.Payment;
using iTechArtPizzaDelivery.Domain.Services;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(PaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService ??
                              throw new ArgumentNullException(nameof(paymentService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _paymentService.GetAllAsync());
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync(PaymentAddRequest request)
        {
            return Ok(await _paymentService.AddAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _paymentService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
