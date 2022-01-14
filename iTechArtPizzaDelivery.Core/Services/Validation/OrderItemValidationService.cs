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
    public class OrderItemValidationService : IOrderItemValidationService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemValidationService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
        }

        public async Task OrderItemExistsAsync(int id)
        {
            if (!await _orderItemRepository.IsExists(id))
            {
                throw new HttpStatusCodeException(404, "Item not found");
            }
        }
    }
}
