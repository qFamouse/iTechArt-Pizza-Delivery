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
        Task<List<Order>> GetAllByPageAsync(int pageNumber);
        Task<Order> GetDetailByIdAsync(int id);
        Task<List<Order>> GetAllDetailedByQueryAsync(OrderQuery query);
        Task<Order> GetDetailByQueryAsync(OrderQuery query);
        Task<Order> GetByQueryAsync(OrderQuery query);
    }
}
