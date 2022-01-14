using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;

namespace iTechArtPizzaDelivery.Core.Services.Validation
{
    public class OrderValidationService : IOrderValidationService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderValidationService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        public void OrderReadyToDelivery(Order order)
        {
            if (order.Payment is null && order.PaymentId is null)
            {
                throw new HttpStatusCodeException(400, "No payment method");
            }

            if (order.Delivery is null && order.DeliveryId is null)
            {
                throw new HttpStatusCodeException(400, "No delivery method");
            }
        }

        public void OrderInProgress(Order order)
        {
            if (order.Status != (short) Status.InProgress)
            {
                throw new HttpStatusCodeException(400, "Order is not in progress");
            }
        }
    }
}
