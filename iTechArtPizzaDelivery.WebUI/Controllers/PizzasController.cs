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
    public class PizzasController : ControllerBase
    {
        private readonly PizzasService _pizzasService;

        public PizzasController(PizzasService pizzasService)
        {
            _pizzasService = pizzasService ??
                             throw new ArgumentNullException(nameof(pizzasService), "Service is null");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_pizzasService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pizzasService.GetById(id));
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Pizza pizza)
        {
            return Ok(_pizzasService.Add(pizza));
        }
    }
}
