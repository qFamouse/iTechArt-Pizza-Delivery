using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.Size;
using iTechArtPizzaDelivery.Domain.Services;
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
            _sizesService = sizesService ??
                            throw new ArgumentNullException(nameof(sizesService), "Service is null");
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
        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] SizeAddRequest sAddRequest)
        {
            return Ok(await _sizesService.AddAsync(sAddRequest));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _sizesService.DeleteAsync(id);
            return Ok();
        }
    }
}
