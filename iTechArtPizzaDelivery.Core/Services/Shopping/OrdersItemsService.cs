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
    public class OrdersItemsService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaSizeRepository _pizzaSizeRepository;
        private readonly IIdentityService _identityService;
        private readonly IOrderValidationService _orderValidationService;
        private readonly IOrderItemValidationService _orderItemValidationService;

        public OrdersItemsService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository,
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

        public async Task<List<OrderItem>> GetByOrderIdAsync(int id)
        {
            return await _orderItemRepository.GetAllByOrderIdAsync(id);
        }

        public async Task DeleteByIdAsync(int orderItemId)
        {
            await _orderItemValidationService.OrderItemExistsAsync(orderItemId);

            // Search order
            var order = await _orderRepository.GetDetailedByQueryAsync(new OrderQuery()
            {
                OrderId = orderItemId, // TODO: We need order ID!
                UserId = _identityService.Id
            }) ?? throw new HttpStatusCodeException(400, "Order access protection");

            // If order in progress then we can delete item from this order
            _orderValidationService.OrderInProgress(order);
            await _orderItemRepository.DeleteByIdAsync(orderItemId);
            await _orderItemRepository.Save(); // TODO: Is maybe redundant

            order.Recalculate();
            await _orderRepository.Save();
        }

        public async Task<OrderItem> UpdateByIdAsync(int orderItemId, OrderItemUpdateRequest request)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(orderItemId) ??
                            throw new HttpStatusCodeException(400, "Item not found");

            // Check order
            var order = await _orderRepository.GetByQueryAsync(new OrderQuery()
            {
                OrderId = orderItem.OrderId,
                UserId = _identityService.Id
            }) ?? throw new HttpStatusCodeException(400, "Order access protection");

            // Editing
            orderItem.Quantity = request.Quantity;
            orderItem.Recalculate();
            order.Recalculate();
            await _orderRepository.Save();
            return orderItem;
        }

        public async Task<OrderItem> AddAsync(OrderItemAddRequest request)
        {
            var pizzaSize = await _pizzaSizeRepository.GetDetailByIdAsync(request.PizzaSizesId) ??
                            throw new HttpStatusCodeException(400, "Pizza not found");

            var order = await _orderRepository.GetDetailedByQueryAsync(new OrderQuery()
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
            order.Recalculate();

            await _orderItemRepository.InsertAsync(orderItem);
            await _orderItemRepository.Save();
            return orderItem;

            //order.OrderItems.Add(orderItem);
            //await _orderRepository.SaveChangesAsync();

            //var query = new OrderQuery() // Coming Soon (Change to Constructor)
            //{
            //    UserId = _identityService.Id,
            //    Status = (short) Status.InProgress
            //};

            //Order order = await _orderRepository.GetDetailedByQueryAsync(query);

            //if (order is not null)
            //{
            //    OrderItem requestedItem = order?.OrderItems.Find(oi => oi.PizzaSizeId == pizzaSize.Id);

            //    if (requestedItem is not null)
            //    {
            //        return await UpdateAsync(new OrderItemUpdateRequest() // Coming Soon (Change to Constructor)
            //        {
            //            OrderItemId = requestedItem.Id,
            //            Quantity = (short)(requestedItem.Quantity + request.Quantity)
            //        });
            //    }
            //}
            //else
            //{
            //    order = new Order() // Coming Soon (Change to Constructor)
            //    {
            //        UserId = _identityService.Id,
            //        Status = (short)Status.InProgress,
            //        CreateAt = DateTime.Now
            //    };

            //    order = await _orderRepository.DeleteAsync(order);
            //}

        }


    }
}
