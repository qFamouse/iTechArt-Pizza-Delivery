using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class PromocodesService : IPromocodeService
    {
        private readonly IPromocodeRepository _promocodeRepository;

        public PromocodesService(IPromocodeRepository promocodeRepository)
        {
            _promocodeRepository = promocodeRepository ??
                                   throw new ArgumentNullException(nameof(promocodeRepository), "Interface is null");
        }

        public async Task<List<Promocode>> GetAllAsync()
        {
            return await _promocodeRepository.GetAllAsync();
        }
    }
}
