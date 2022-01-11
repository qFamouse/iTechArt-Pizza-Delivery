using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.Promocode;
using iTechArtPizzaDelivery.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocodesController : ControllerBase
    {
        private readonly IPromocodeService _promocodesService;

        public PromocodesController(IPromocodeService promocodesService)
        {
            _promocodesService = promocodesService ??
                                 throw new ArgumentNullException(nameof(promocodesService), "Service is null");

        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _promocodesService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] PromocodeAddRequest request)
        {
            return Ok(await _promocodesService.AddAsync(request));
        }
    }
}
