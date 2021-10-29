using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Fakes;
using Microsoft.AspNetCore.Mvc;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")] // Define route (for mapping to queries)
    [ApiController] // Define that is controller class 
    public class PizzasSizesController : ControllerBase
    {
        private readonly PizzaSizesService _pizzaSizesService;

        public PizzasSizesController(PizzaSizesService pizzaSizesService)
        {
            _pizzaSizesService = pizzaSizesService ?? // If pizzasSizesRepository is null
                                 throw new ArgumentNullException(nameof(pizzaSizesService), "Service pizzaSizesService is null");
        }

        [HttpGet]
        public List<PizzaSize> GetAll()
        {
            return _pizzaSizesService.GetAll();
        }

        [HttpGet("{id}")]
        public PizzaSize GetById(int id)
        {
            return _pizzaSizesService.GetById(id);
        }
    }
}
