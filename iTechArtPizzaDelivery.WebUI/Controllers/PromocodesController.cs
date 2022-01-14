using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IPromocodeService _promocodeService;
        private readonly IMapper _mapper;

        public PromocodesController(IPromocodeService promocodeService, IMapper mapper)
        {
            _promocodeService = promocodeService ?? throw new ArgumentNullException(nameof(promocodeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _promocodeService.GetAllAsync());
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet("{code}")]
        public async Task<ActionResult> GetByCodeAsync(string code)
        {
            return Ok(await _promocodeService.GetByCodeAsync(code));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> InsertAsync([FromBody] PromocodeInsertRequest request)
        {
            return Ok(await _promocodeService.InsertAsync(request));
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteAsync(string code)
        {
            await _promocodeService.DeleteByCodeAsync(code);
            return Ok();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{code}")]
        public async Task<ActionResult> UpdateAsync(string code, PromocodeUpdateRequest request)
        {
            return Ok(await _promocodeService.UpdateByCodeAsync(code, request));
        }
    }
}