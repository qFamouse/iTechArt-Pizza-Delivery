using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticalController : ControllerBase
    {
        private readonly IAnalyticalService _analyticalService;

        public AnalyticalController(IAnalyticalService analyticalService)
        {
            _analyticalService = analyticalService ?? throw new ArgumentNullException(nameof(analyticalService));
        }

        [HttpGet("{month}")]
        public async Task<ActionResult> GetBestSellingPizzaAsync(int month)
        {
            return Ok(await _analyticalService.GetBestSellingPizzaByMonthAsync(month));
        }
    }
}