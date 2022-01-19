using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticalController : ControllerBase
    {
        private readonly IAnalyticalService _analyticalService;
        private readonly IMapper _mapper;

        public AnalyticalController(IAnalyticalService analyticalService, IMapper mapper)
        {
            _analyticalService = analyticalService ?? throw new ArgumentNullException(nameof(analyticalService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("best_pizza/{month}")]
        public async Task<ActionResult> GetBestSellingPizzaAsync(int month)
        {
            return Ok(await _analyticalService.GetBestSellingPizzaByMonthAsync(month));
        }

        [HttpGet("regular_users")]
        public async Task<ActionResult> GetRegularCustomersAsync()
        {
            var users = await _analyticalService.GetRegularCustomersAsync();
            var usersView = _mapper.Map<List<User>, List<UserView>>(users);
            return Ok(usersView);
        }
    }
}