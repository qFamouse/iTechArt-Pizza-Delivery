using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Extensions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Account;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Queries;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Services.Shopping
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaSizeRepository _pizzaSizeRepository;
        private readonly IIdentityService _identityService;
        private readonly IOrderValidationService _orderValidationService;
        private readonly IOrderItemValidationService _orderItemValidationService;

        public OrderItemService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository,
            IPizzaSizeRepository pizzaSizeRepository, IIdentityService identityService,
            IOrderValidationService orderValidationService, IOrderItemValidationService orderItemValidationService)
        {
            _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _pizzaSizeRepository = pizzaSizeRepository ?? throw new ArgumentNullException(nameof(pizzaSizeRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _orderValidationService =
                orderValidationService ?? throw new ArgumentNullException(nameof(orderValidationService));
            _orderItemValidationService = orderItemValidationService ??
                                          throw new ArgumentNullException(nameof(orderItemValidationService));
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            // Search order
            var order = await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                UserId = _identityService.Id,
                Status = (short) Status.InProgress
            }) ?? throw new HttpStatusCodeException(400, "Order not found");

            return await _orderItemRepository.GetAllByOrderIdAsync(order.Id);
        }

        public async Task DeleteByIdAsync(int orderItemId)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(orderItemId) ??
                            throw new HttpStatusCodeException(400, "Item not found");


            // Search order
            var order = await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                OrderId = orderItem.OrderId,
                UserId = _identityService.Id,
                Status = (short) Status.InProgress
            }) ?? throw new HttpStatusCodeException(400, "Order access protection");

            // Deleting orderItem
            // _orderValidationService.OrderInProgress(order); -- redundant because we check status in order request
            await _orderItemRepository.DeleteByIdAsync(orderItemId);
            await _orderItemRepository.Save();

            order.Recalculate();
            await _orderRepository.Save();
        }

        public async Task<OrderItem> UpdateByIdAsync(int orderItemId, OrderItemUpdateRequest request)
        {
            var orderItem = await _orderItemRepository.GetDetailByIdAsync(orderItemId) ??
                            throw new HttpStatusCodeException(400, "Item not found");

            // Check order
            var order = await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                OrderId = orderItem.OrderId,
                UserId = _identityService.Id,
                Status = (short) Status.InProgress
            }) ?? throw new HttpStatusCodeException(400, "Order access protection");

            // Editing
            orderItem.Quantity = request.Quantity;
            orderItem.Recalculate();
            order.Recalculate();
            await _orderRepository.Save();
            return orderItem;
        }

        public async Task<OrderItem> AddAsync(OrderItemInsertRequest request)
        {
            var pizzaSize = await _pizzaSizeRepository.GetDetailByIdAsync(request.PizzaSizesId) ??
                            throw new HttpStatusCodeException(400, "Pizza not found");

            var order = await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                UserId = _identityService.Id,
                Status = (short) Status.InProgress
            });

            if (order is not null)
            {
                // Looking for the same product in this order
                var existingOrderItem = order?.OrderItems.SingleOrDefault(oi => oi.PizzaSizeId == pizzaSize.Id);

                if (existingOrderItem is not null)
                {
                    return await UpdateByIdAsync(existingOrderItem.Id, new OrderItemUpdateRequest()
                    {
                        Quantity = (short) (existingOrderItem.Quantity + request.Quantity)
                    });
                }
            }
            else
            {
                order = new Order()
                {
                    UserId = _identityService.Id,
                    Status = (short) Status.InProgress,
                    CreateAt = DateTime.Now
                };

                await _orderRepository.InsertAsync(order);
                await _orderRepository.Save();
            }

            var orderItem = new OrderItem()
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
            await _orderItemRepository.InsertAsync(orderItem);
            await _orderItemRepository.Save();

            order.Recalculate();
            await _orderRepository.Save();

            return orderItem;
        }


    }
}
