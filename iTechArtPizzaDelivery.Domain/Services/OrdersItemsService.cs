using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class OrdersItemsService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;

        public OrdersItemsService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository ??
                                   throw new ArgumentNullException(nameof(orderItemRepository), "Interface is null");

            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository), "Interface is null");
        }

        #region Public Methods

        #region Getters

        public async Task<List<OrderItem>> GetItemsByOrderIdAsync(int id)
        {
            return await _orderItemRepository.GetAllByOrderIdAsync(id);
        }

        #endregion

        #region Setters

        public async Task DeleteItemByIdAsync(int id)
        {
            await _orderItemRepository.SaveChangesAsync();
        }

        public async Task<OrderItem> EditItemByIdAsync(OrderItemEditRequest request)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemId);

            orderItem.Quantity = request.Quantity;

            RecalculateItem(orderItem);
            await _orderItemRepository.SaveChangesAsync();

            return orderItem;
        }

        #endregion

        #endregion

        #region Private Methods

        private void RecalculateItem(OrderItem orderItem)
        {
            double weight = orderItem.PizzaSize.Weight;
            double price = orderItem.PizzaSize.Price * orderItem.Quantity;

            foreach (var pizzaIngredient in orderItem.PizzaSize.PizzaIngredients)
            {
                weight += pizzaIngredient.Weight;
                price += pizzaIngredient.Ingredient.Price;
            }

            orderItem.Weight = weight;
            orderItem.Price = price;
        }

        public async Task<OrderItem> AddAsync(OrderItemAddRequest request)
        {
            int UserId = 1; // Coming Soon (Identity)




            return null;
        }

        #endregion
    }
}
