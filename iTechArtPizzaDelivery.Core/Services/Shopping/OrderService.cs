using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Extensions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Account;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Queries;

namespace iTechArtPizzaDelivery.Core.Services.Shopping
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IPromocodeRepository _promocodeRepository;
        private readonly IPromocodeValidationService _promocodeValidationService;
        private readonly IOrderValidationService _orderValidationService;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IPaymentRepository paymentRepository,
            IDeliveryRepository deliveryRepository, IPromocodeRepository promocodeRepository,
            IPromocodeValidationService promocodeValidationService, IOrderValidationService orderValidationService,
            IIdentityService identityService, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
            _deliveryRepository = deliveryRepository ?? throw new ArgumentNullException(nameof(deliveryRepository));
            _promocodeRepository = promocodeRepository ?? throw new ArgumentNullException(nameof(promocodeRepository));
            _promocodeValidationService = promocodeValidationService ??
                                          throw new ArgumentNullException(nameof(promocodeValidationService));
            _orderValidationService =
                orderValidationService ?? throw new ArgumentNullException(nameof(orderValidationService));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetDetailByIdAsync(int id)
        {
            return await _orderRepository.GetDetailByIdAsync(id) ??
                   throw new HttpStatusCodeException(404, "Order not found");
        }

        public async Task<Order> GetUserDetailAsync()
        {
            return await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                Status = (short)Status.InProgress,
                UserId = _identityService.Id
            }) ?? throw new HttpStatusCodeException(404, "Order not found");
        }

        public async Task AttachPromocodeAsync(string code)
        {
            // Search order 'in progress' in current user data
            var order = await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                Status = (short) Status.InProgress,
                UserId = _identityService.Id
            }) ?? throw new HttpStatusCodeException(404, "Order not found");

            if (order.Promocode is not null)
            {
                throw new HttpStatusCodeException(400, "The order already has an active promo code");
            }

            // Search promocode
            var promocode = await _promocodeRepository.GetByCodeAsync(code) ??
                            throw new HttpStatusCodeException(404, "Promo code not found");

            _promocodeValidationService.PromocodeIsValid(promocode);

            // Attaching promocode
            order.Promocode = promocode;
            order.PromocodeId = promocode.Id;
            order.Recalculate();
            await _orderRepository.Save();
        }

        public async Task AttachPaymentAsync(int paymentId)
        {
            // Search order 'in progress' in current user data
            var order = await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                Status = (short)Status.InProgress,
                UserId = _identityService.Id
            }) ?? throw new HttpStatusCodeException(404, "Order not found");

            // Search payment
            var payment = await _paymentRepository.GetByIdAsync(paymentId) ??
                throw new HttpStatusCodeException(404, "Payment not found");

            // Attaching payment
            order.Payment = payment;
            order.PaymentId = payment.Id;
            await _orderRepository.Save();
        }

        public async Task AttachDeliveryAsync(int deliveryId)
        {
            // Search order 'in progress' in current user data
            var order = await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                Status = (short)Status.InProgress,
                UserId = _identityService.Id
            }) ?? throw new HttpStatusCodeException(404, "Order not found");

            // Search payment
            var delivery = await _deliveryRepository.GetByIdAsync(deliveryId) ??
                          throw new HttpStatusCodeException(404, "Delivery not found");

            // Attaching payment
            order.Delivery = delivery;
            order.DeliveryId = delivery.Id;
            await _orderRepository.Save();
        }

        public async Task ProcessOrderAsync()
        {
            // Search order 'in progress' in current user data
            var order = await _orderRepository.GetDetailByQueryAsync(new OrderQuery()
            {
                Status = (short) Status.InProgress,
                UserId = _identityService.Id
            }) ?? throw new HttpStatusCodeException(404, "Order not found");

            _orderValidationService.OrderReadyToDelivery(order);

            order.Recalculate();
            order.Status = (short) Status.WaitingDelivery;
            await _orderRepository.Save();
        }
    }
}
