using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Services;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly SizesService _sizesService;

        public SizesController(SizesService sizesService)
        {
            _sizesService = sizesService ??
                            throw new ArgumentNullException(nameof(sizesService), "Service is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _sizesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            return Ok(await _sizesService.GetByIdAsync(id));
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync([FromBody] Size size)
        {
            return Ok(await _sizesService.AddAsync(size));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _sizesService.DeleteAsync(id);
            return Ok();
        }
    }
}
