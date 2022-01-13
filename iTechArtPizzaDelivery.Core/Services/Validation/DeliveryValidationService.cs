using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;

namespace iTechArtPizzaDelivery.Core.Services.Validation
{
    public class DeliveryValidationService : IDeliveryValidationService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public DeliveryValidationService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository ??
                                  throw new ArgumentNullException(nameof(deliveryRepository), "Interface is null");
        }

        public async Task DeliveryExistsAsync(int id)
        {
            if (!await _deliveryRepository.IsExists(id))
            {
                throw new HttpStatusCodeException(404, "Delivery not found");
            }
        }
    }
}