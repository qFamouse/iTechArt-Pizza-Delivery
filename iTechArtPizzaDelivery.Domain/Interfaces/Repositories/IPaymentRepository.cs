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
        #region Getters

        public Task<List<Payment>> GetAllAsync();

        #endregion

        #region Setters

        public Task DeleteByIdAsync(int id);
        public Task<Payment> AddAsync(PaymentAddRequest request);

        #endregion
    }
}
