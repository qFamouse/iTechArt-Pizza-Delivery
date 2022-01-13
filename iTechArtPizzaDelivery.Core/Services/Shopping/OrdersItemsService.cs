using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Extensions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Account;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Queries;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Services.Shopping
{
    public class OrdersItemsService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaSizeRepository _pizzaSizeRepository;
        private readonly IIdentityService _identityService;

        public OrdersItemsService(IOrderItemRepository orderItemRepository, 
            IOrderRepository orderRepository, 
            IPizzaSizeRepository pizzaSizeRepository,
            IIdentityService identityService)
        {
            _orderItemRepository = orderItemRepository ??
                                   throw new ArgumentNullException(nameof(orderItemRepository), "Interface is null");

            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository), "Interface is null");

            _pizzaSizeRepository = pizzaSizeRepository ??
                                   throw new ArgumentNullException(nameof(pizzaSizeRepository), "Interface is null");

            _identityService = identityService ??
                               throw new ArgumentNullException(nameof(identityService), "Interface is null");
        }

        public async Task<List<OrderItem>> GetItemsByOrderIdAsync(int id)
        {
            return await _orderItemRepository.GetAllByOrderIdAsync(id);
        }

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

            orderItem.Recalculate();

            await _orderItemRepository.SaveChangesAsync();

            return orderItem;
        }

        public async Task<OrderItem> AddAsync(OrderItemAddRequest request)
        {
            PizzaSize pizzaSize = await _pizzaSizeRepository.GetDetailByIdAsync(request.PizzaSizesId);

            var query = new OrderQuery() // Coming Soon (Change to Constructor)
            {
                UserId = _identityService.Id,
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
                    UserId = _identityService.Id,
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

            orderItem.Recalculate();
            await _orderItemRepository.Add(orderItem);


            //order.OrderItems.Add(orderItem);
            order.Recalculate();
            await _orderRepository.SaveChangesAsync();
            return orderItem;
        }
    }
}
