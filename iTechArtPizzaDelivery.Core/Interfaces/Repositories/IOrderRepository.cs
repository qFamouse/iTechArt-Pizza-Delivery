using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Queries;
using iTechArtPizzaDelivery.Core.Requests.Order;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetDetailByIdAsync(int id);
        Task<List<Order>> GetDetailedOrdersAsync(OrderQuery query);
        Task<Order> GetDetailedOrderAsync(OrderQuery query);
        Task DeleteByIdAsync(int id);
        Task<Order> AddAsync(Order order);
        Task SaveChangesAsync();
    }
}
