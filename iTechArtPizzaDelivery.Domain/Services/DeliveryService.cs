using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.Delivery;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class DeliveryService : IDeliveriesService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository ??
                                  throw new ArgumentNullException(nameof(deliveryRepository), "Interface is null");
        }

        public async Task<Delivery> AddAsync(DeliveryAddRequest request)
        {
            return await _deliveryRepository.AddAsync(request);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _deliveryRepository.DeleteByIdAsync(id);
        }

        public async Task<List<Delivery>> GetAllAsync()
        {
            return await _deliveryRepository.GetAllAsync();
        }
    }
}
