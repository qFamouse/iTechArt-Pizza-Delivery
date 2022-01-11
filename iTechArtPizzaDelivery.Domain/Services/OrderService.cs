using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Extensions;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Queries;
using iTechArtPizzaDelivery.Domain.Requests.Order;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPromocodeRepository _promocodeRepository;
        private readonly IIdentityService _identityService;

        public OrderService(IOrderRepository orderRepository,
            IPromocodeRepository promocodeRepository, 
            IIdentityService identityService)
        {
            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository), "Interface is null");

            _promocodeRepository = promocodeRepository ??
                                   throw new ArgumentNullException(nameof(promocodeRepository), "Interface is null");

            _identityService = identityService ??
                               throw new ArgumentNullException(nameof(identityService), "Interface is null");
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetDetailByIdAsync(int id)
        {
            return await _orderRepository.GetDetailByIdAsync(id);
        }

        public async Task AttachPromocode(OrderAttachPromocodeRequest request)
        {
            // Get Initial Data //
            Order order = await _orderRepository.GetDetailByIdAsync(request.OrderId);
            Promocode promocode = await _promocodeRepository.GetByCodeAsync(request.Code);

            // Check Order to existing promocode //
            if (order.Promocode is not null)
            {
                throw new ArgumentException("The order already has an active promo code", nameof(order.Promocode));
            }

            // Attach Promocode to Order //
            order.Promocode = promocode;
            order.PromocodeId = promocode.Id;

            // Recalculate Order //
            order.Recalculate();

            // Save changes //
            await _orderRepository.SaveChangesAsync();
        }

        public async Task ProcessOrder()
        {
            // Get Initial Data //
            OrderQuery query = new OrderQuery()
            {
                Status = (short)Status.InProgress,
                UserId = _identityService.Id,
            };

            var order = await _orderRepository.GetDetailedOrderAsync(query);

            // Check order //
            if (order.PaymentId is null || order.DeliveryId is null)
            {
                throw new ArgumentException("Delivery and payment method are not specified");
            }

            // Recalculate order - just in case //
            order.Recalculate();

            // Set Status //
            order.Status = (short)Status.WaitingDelivery;

            // Save Changes //
            await _orderRepository.SaveChangesAsync();

        }
    }
}
