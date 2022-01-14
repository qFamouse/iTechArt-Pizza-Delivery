using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Requests.Size;
using iTechArtPizzaDelivery.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizesService _sizesService;

        public SizesController(ISizesService sizesService)
        {
            _sizesService = sizesService ?? throw new ArgumentNullException(nameof(sizesService));
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _sizesService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _sizesService.GetByIdAsync(id));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] SizeAddRequest request)
        {
            return Ok(await _sizesService.InsertAsync(request));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _sizesService.DeleteByIdAsync(id);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] SizeUpdateRequest request)
        {
            return Ok(await _sizesService.UpdateByIdAsync(id, request));
        }
    }
}
