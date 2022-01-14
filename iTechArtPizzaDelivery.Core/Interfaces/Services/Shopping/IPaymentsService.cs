using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Payment;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IPaymentsService
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task<Payment> InsertAsync(PaymentAddRequest request);
        Task DeleteByIdAsync(int id);
        Task<Payment> UpdateByIdAsync(int id, PaymentUpdateRequest request);
    }
}
