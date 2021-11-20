using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Order;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        #region Getters

        public Task<List<Order>> GetAllAsync();
        public Task<Order> GetByIdAsync(int id);

        #endregion


        public Task SaveChangesAsync();
    }
}
