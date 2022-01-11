using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.Promocode;

namespace iTechArtPizzaDelivery.Domain.Services
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
