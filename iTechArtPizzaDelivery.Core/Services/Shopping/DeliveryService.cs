using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.Delivery;

namespace iTechArtPizzaDelivery.Core.Services.Shopping
{
    public class DeliveryService : IDeliveriesService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IDeliveryValidationService _deliveryValidationService;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository,
            IDeliveryValidationService deliveryValidationService, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository ?? throw new ArgumentNullException(nameof(deliveryRepository));

            _deliveryValidationService = deliveryValidationService ??
                                         throw new ArgumentNullException(nameof(deliveryValidationService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            await _deliveryRepository.InsertAsync(delivery);
            await _deliveryRepository.Save();
            return delivery;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _deliveryRepository.DeleteByIdAsync(id);
        }

        public async Task<Delivery> UpdateByIdAsync(int id, DeliveryUpdateRequest request)
        {
            await _deliveryValidationService.DeliveryExistsAsync(id);
            var delivery = _mapper.Map<Delivery>(request);
            delivery.Id = id;

            _deliveryRepository.Update(delivery);
            await _deliveryRepository.Save();

            return delivery;
        }
    }
}
