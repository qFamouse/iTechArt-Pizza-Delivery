using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Requests.Delivery;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace iTechArtPizzaDelivery.Core.Services
{
    public class DeliveryService : IDeliveriesService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository ??
                                  throw new ArgumentNullException(nameof(deliveryRepository), "Interface is null");

            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }
        public async Task<List<Delivery>> GetAllAsync()
        {
            return await _deliveryRepository.GetAllAsync();
        }

        public async Task<Delivery> GetByIdAsync(int id)
        {
            return await _deliveryRepository.GetByIdAsync(id);
        }

        public async Task<Delivery> AddAsync(DeliveryAddRequest request)
        {
            var delivery = _mapper.Map<Delivery>(request);
            return await _deliveryRepository.InsertAsync(delivery);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _deliveryRepository.DeleteByIdAsync(id);
        }

        public async Task<Delivery> UpdateByIdAsync(int id, DeliveryUpdateRequest request)
        {
            var delivery = _mapper.Map<Delivery>(request);
            delivery.Id = id;

            _deliveryRepository.Update(delivery);
            await _deliveryRepository.Save();

            return delivery;
        }
    }
}
