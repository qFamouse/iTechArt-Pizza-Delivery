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
        private readonly PizzaSizesService _pizzaSizesService = new PizzaSizesService(new PizzasSizesFakeRepository());

        [HttpGet]
        public List<PizzaSize> GetAll()
        {
            return _pizzaSizesService.GetAll();
        }
    }
}
