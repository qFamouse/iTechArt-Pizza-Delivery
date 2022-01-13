using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Requests.Promocode;

namespace iTechArtPizzaDelivery.Core.Services.Shopping
{
    public class PromocodesService : IPromocodeService
    {
        private readonly IPromocodeRepository _promocodeRepository;
        private readonly IMapper _mapper;

        public PromocodesService(IPromocodeRepository promocodeRepository, IMapper mapper)
        {
            _promocodeRepository = promocodeRepository ??
                                   throw new ArgumentNullException(nameof(promocodeRepository), "Interface is null");

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        public async Task<Promocode> AddAsync(PromocodeAddRequest request)
        {
            var promocode = _mapper.Map<Promocode>(request);
            return await _promocodeRepository.AddAsync(promocode);
        }

        public async Task<List<Promocode>> GetAllAsync()
        {
            return await _promocodeRepository.GetAllAsync();
        }

        
    }
}
