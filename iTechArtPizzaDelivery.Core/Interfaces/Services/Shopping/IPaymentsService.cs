using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Payment;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IPaymentsService
    {
        Task<List<Payment>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Payment> AddAsync(PaymentAddRequest request);
    }
}
