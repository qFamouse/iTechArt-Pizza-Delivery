using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Payment;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Payment> AddAsync(PaymentAddRequest request);
    }
}
