using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Queries;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetDetailByIdAsync(int id);
        Task<List<Order>> GetAllDetailedByQueryAsync(OrderQuery query);
        Task<Order> GetDetailedByQueryAsync(OrderQuery query);
        Task<Order> GetByQueryAsync(OrderQuery query);
    }
}
