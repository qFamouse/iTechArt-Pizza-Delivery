using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.Delivery;
using iTechArtPizzaDelivery.Core.Requests.Payment;

namespace iTechArtPizzaDelivery.Core.Services.Shopping
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentValidationService _paymentValidationService;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IPaymentValidationService paymentValidationService,
            IMapper mapper)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
            _paymentValidationService = paymentValidationService ??
                                        throw new ArgumentNullException(nameof(paymentValidationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _paymentRepository.GetByIdAsync(id) ??
                   throw new HttpStatusCodeException(404, "Payment not found");
        }

        public async Task<Payment> InsertAsync(PaymentInsertRequest request)
        {
            var payment = _mapper.Map<Payment>(request);
            await _paymentRepository.InsertAsync(payment);
            await _paymentRepository.Save();
            return payment;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _paymentValidationService.PaymentExistsAsync(id);
            await _paymentRepository.DeleteByIdAsync(id);
            await _paymentRepository.Save();
        }

        public async Task<Payment> UpdateByIdAsync(int id, PaymentUpdateRequest request)
        {
            await _paymentValidationService.PaymentExistsAsync(id);
            var payment = _mapper.Map<Payment>(request);
            payment.Id = id;

            _paymentRepository.Update(payment);
            await _paymentRepository.Save();

            return payment;
        }
    }
}
