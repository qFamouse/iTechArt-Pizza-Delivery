using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.Order;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository), "Interface is null");
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task AddPromocode(OrderAddPromocodeRequest request)
        {
            var order = await _orderRepository.GetOrderById(request.OrderId);
            var promocode = await _orderRepository.GetPromocodeByCode(request.Code);

            if (order.Promocode is not null)
            {
                throw new ArgumentException("The order already has an active promo code", nameof(order.Promocode));
            }

            switch ((MeasureType)promocode.Measure)
            {
                case MeasureType.Percent:
                    order.Price *= promocode.Discount;
                    break;
                case MeasureType.Money:
                    order.Price -= promocode.Discount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(promocode.Measure), "Invalid measure value");
            }

            order.Promocode = promocode;

            await _orderRepository.SaveChangesAsync();
        }
    }
}
