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
