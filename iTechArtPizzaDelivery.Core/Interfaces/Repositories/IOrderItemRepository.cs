using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<List<OrderItem>> GetAllByOrderIdAsync(int id);
    }
}
