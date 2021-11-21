using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Queries;
using iTechArtPizzaDelivery.Domain.Requests.Order;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        #region Getters

        public Task<List<Order>> GetAllAsync();
        public Task<Order> GetByIdAsync(int id);
        public Task<Order> GetDetailByIdAsync(int id);
        public Task<List<Order>> GetDetailedOrdersAsync(OrderQuery query);
        public Task<Order> GetDetailedOrderAsync(OrderQuery query);

        #endregion

        public Task<Order> Add(Order order);
        public Task SaveChangesAsync();
    }
}
