using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Payment;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Payment> AddAsync(PaymentAddRequest request);
    }
}
