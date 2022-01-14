using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Requests.Promocode;
using iTechArtPizzaDelivery.Core.Services;
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
            _promocodesService = promocodesService ?? throw new ArgumentNullException(nameof(promocodesService));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _promocodesService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("{code}")]
        public async Task<ActionResult> GetByCodeAsync(string code)
        {
            return Ok(await _promocodesService.GetByCodeAsync(code));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] PromocodeAddRequest request)
        {
            return Ok(await _promocodesService.InsertAsync(request));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteAsync(string code)
        {
            await _promocodesService.DeleteByCodeAsync(code);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{code}")]
        public async Task<ActionResult> UpdateAsync(string code, PromocodeUpdateRequest request)
        {
            return Ok(await _promocodesService.UpdateByCodeAsync(code, request));
        }
    }
}