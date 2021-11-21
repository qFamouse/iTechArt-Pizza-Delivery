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
        private readonly IPromocodeRepository _promocodeRepository;

        public OrderService(IOrderRepository orderRepository, IPromocodeRepository promocodeRepository)
        {
            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository), "Interface is null");

            _promocodeRepository = promocodeRepository ??
                                   throw new ArgumentNullException(nameof(promocodeRepository), "Interface is null");
        }

        #region Public Methods

        #region Getters

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetDetailByIdAsync(int id)
        {
            return await _orderRepository.GetDetailByIdAsync(id);
        }

        #endregion

        #region Setters

        public async Task AttachPromocode(OrderAttachPromocodeRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            var promocode = await _promocodeRepository.GetByCode(request.Code);

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

        #endregion

        #endregion

        #region Private Methods

        private void RecalculateOrder(Order order)
        {
            double price;


        }

        #endregion
    }
}
