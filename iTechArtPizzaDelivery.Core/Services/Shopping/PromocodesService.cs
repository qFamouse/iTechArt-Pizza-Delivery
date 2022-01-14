using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.Promocode;

namespace iTechArtPizzaDelivery.Core.Services.Shopping
{
    public class PromocodesService : IPromocodeService
    {
        private readonly IPromocodeRepository _promocodeRepository;
        private readonly IPromocodeValidationService _promocodeValidationService;
        private readonly IMapper _mapper;

        public PromocodesService(IPromocodeRepository promocodeRepository, IPromocodeValidationService promocodeValidationService, IMapper mapper)
        {
            _promocodeRepository = promocodeRepository;
            _promocodeValidationService = promocodeValidationService;
            _mapper = mapper;
        }

        public async Task<List<Promocode>> GetAllAsync()
        {
            return await _promocodeRepository.GetAllAsync();
        }

        public async Task<Promocode> GetByCodeAsync(string code)
        {
            return await _promocodeRepository.GetByCodeAsync(code) ??
                   throw new HttpStatusCodeException(404, "Promocode not found");
        }

        public async Task<Promocode> InsertAsync(PromocodeAddRequest request)
        {
            var promocode = _mapper.Map<Promocode>(request);
            await _promocodeRepository.InsertAsync(promocode);
            await _promocodeRepository.Save();
            return promocode;
        }

        public async Task DeleteByCodeAsync(string code)
        {
            var promocode = await GetByCodeAsync(code); // TODO: Maybe tracked promocode
            await _promocodeRepository.DeleteByIdAsync(promocode.Id);
            await _promocodeRepository.Save();
        }

        public async Task<Promocode> UpdateByCodeAsync(string code, PromocodeUpdateRequest request)
        {
            var promocode = await _promocodeRepository.GetByCodeAsync(code) ??
                   throw new HttpStatusCodeException(404, "Promocode not found");

            promocode.Code = request.Code ?? code;
            promocode.Discount = request.Discount ?? promocode.Discount;
            promocode.Measure = request.Measure ?? promocode.Measure;
            promocode.StartDate = request.StartDate ?? promocode.StartDate;
            promocode.EndDate = request.EndDate ?? promocode.EndDate;

            _promocodeRepository.Update(promocode);
            await _promocodeRepository.Save();

            return promocode;
        }
    }
}