using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetAll()
        {
            return Ok(_sizesService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_sizesService.GetById(id));
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Size size)
        {
            return Ok(_sizesService.Add(size));
        }
    }
}
