using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.Payment;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class PaymentService : IPaymentsService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository ??
                                 throw new ArgumentNullException(nameof(paymentRepository), "Interface is null");
        }

        public async Task<Payment> AddAsync(PaymentAddRequest request)
        {
            return await _paymentRepository.AddAsync(request);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _paymentRepository.DeleteByIdAsync(id);
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }
    }
}
