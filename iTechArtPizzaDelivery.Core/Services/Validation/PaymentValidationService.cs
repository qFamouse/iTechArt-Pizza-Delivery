using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;

namespace iTechArtPizzaDelivery.Core.Services.Validation
{
    public class PaymentValidationService : IPaymentValidationService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentValidationService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
        }

        public async Task PaymentExistsAsync(int id)
        {
            if (!await _paymentRepository.IsExists(id))
            {
                throw new HttpStatusCodeException(404, "Payment not found");
            }
        }
    }
}
