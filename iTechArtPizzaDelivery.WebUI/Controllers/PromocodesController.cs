using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Services;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocodesController : ControllerBase
    {
        private readonly PromocodesService _promocodesService;

        public PromocodesController(PromocodesService promocodesService)
        {
            _promocodesService = promocodesService ??
                                 throw new ArgumentNullException(nameof(promocodesService), "Service is null");

        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _promocodesService.GetAllAsync());
        }
    }
}
