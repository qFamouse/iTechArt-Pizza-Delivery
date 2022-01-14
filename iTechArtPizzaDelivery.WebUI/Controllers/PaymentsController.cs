using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Requests.Payment;
using iTechArtPizzaDelivery.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper)
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

        [Authorize(Roles = "Administrator, Moderator, User")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _paymentService.GetByIdAsync(id));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] PaymentInsertRequest request)
        {
            return Ok(await _paymentService.InsertAsync(request));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _paymentService.DeleteByIdAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] PaymentUpdateRequest request)
        {
            await _paymentService.UpdateByIdAsync(id, request);
            return Ok();
        }
    }
}
