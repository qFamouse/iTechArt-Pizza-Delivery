using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Queries;
using iTechArtPizzaDelivery.Domain.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class OrdersItemsService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaSizeRepository _pizzaSizeRepository;

        public OrdersItemsService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IPizzaSizeRepository pizzaSizeRepository)
        {
            _orderItemRepository = orderItemRepository ??
                                   throw new ArgumentNullException(nameof(orderItemRepository), "Interface is null");

            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository), "Interface is null");

            _pizzaSizeRepository = pizzaSizeRepository ??
                                   throw new ArgumentNullException(nameof(pizzaSizeRepository), "Interface is null");
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
            var orderItem = await _orderItemRepository.GetByIdAsync(id);

            int orderId = orderItem.OrderId;

            await _orderItemRepository.DeleteById(id);

            OrderQuery query = new OrderQuery
            {
                OrderId = orderId
            };

            var order = await _orderRepository.GetDetailedOrderAsync(query);

            if (order.OrderItems.Count == 0)
            {
                await _orderRepository.DeleteByIdAsync(orderId);
            }

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

        #endregion

        public async Task<OrderItem> AddAsync(OrderItemAddRequest request)
        {
            int UserId = 2; // Coming Soon (Identity)


            PizzaSize pizzaSize = await _pizzaSizeRepository.GetDetailByIdAsync(request.PizzaSizesId);

            var query = new OrderQuery() // Coming Soon (Change to Constructor)
            {
                UserId = UserId,
                Status = (short) Status.InProgress
            };

            Order order = await _orderRepository.GetDetailedOrderAsync(query);

            if (order is not null)
            {
                OrderItem requestedItem = order?.OrderItems.Find(oi => oi.PizzaSizeId == pizzaSize.Id);

                if (requestedItem is not null)
                {
                    return await EditItemByIdAsync(new OrderItemEditRequest() // Coming Soon (Change to Constructor)
                    {
                        OrderItemId = requestedItem.Id,
                        Quantity = (short)(requestedItem.Quantity + request.Quantity)
                    });
                }
            }
            else
            {
                order = new Order() // Coming Soon (Change to Constructor)
                {
                    UserId = UserId,
                    Status = (short)Status.InProgress,
                    CreateAt = DateTime.Now
                };

                order = await _orderRepository.AddAsync(order);
            }

            OrderItem orderItem = new OrderItem() // Coming Soon (Change to Constructor)
            {
                OrderId = order.Id,
                Order = order,
                PizzaSizeId = pizzaSize.Id,
                PizzaSize = pizzaSize,
                //Price install by RecalculateItem()
                Quantity = request.Quantity,
                CreateAt = DateTime.Now,
                //Weight install by RecalculateItem()
            };

            RecalculateItem(orderItem);
            return await _orderItemRepository.Add(orderItem);
        }
    }
}
