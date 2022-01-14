using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Payment;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task<Payment> InsertAsync(PaymentInsertRequest request);
        Task DeleteByIdAsync(int id);
        Task<Payment> UpdateByIdAsync(int id, PaymentUpdateRequest request);
    }
}
