using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
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
            // Get Initial Data //
            Order order = await _orderRepository.GetDetailByIdAsync(request.OrderId);
            Promocode promocode = await _promocodeRepository.GetByCode(request.Code);
            
            // Check Order to existing promocode //
            if (order.Promocode is not null)
            {
                throw new ArgumentException("The order already has an active promo code", nameof(order.Promocode));
            }

            // Attach Promocode to Order //
            order.Promocode = promocode;
            order.PromocodeId = promocode.Id;

            // Recalculate Order //
            RecalculateOrder(order);

            // Save changes //
            await _orderRepository.SaveChangesAsync();
        }

        #endregion

        #endregion

        #region Private Methods

        private void RecalculateOrder(Order order)
        {
            // Initial Data //
            Promocode promocode = order.Promocode;
            double price = 0;
            
            // Add Item Prices //
            foreach (var orderItem in order.OrderItems)
            {
                price += orderItem.Price;
            }
            
            // If Promocode is exists, then include discount //
            if (promocode is not null)
            {
                switch ((MeasureType) promocode.Measure)
                {
                    case MeasureType.Percent:
                        price *= order.Promocode.Discount / 100;
                        break;
                    case MeasureType.Money:
                        price -= order.Promocode.Discount;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(order.Promocode.Measure), "Invalid measure value");
                }
            }

            // If Price is Negative Value, then it free //
            if (price < 0) { price = 0; }

            // Save price //
            order.Price = price;
        }

        #endregion
    }
}
