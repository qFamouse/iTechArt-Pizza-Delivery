using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAllByOrderIdAsync(int id);
        Task<OrderItem> GetByIdAsync(int id);
        Task<OrderItem> Add(OrderItem orderItem);
        Task DeleteById(int id);

        Task SaveChangesAsync();
        //public Task<OrderItem> EditByIdAsync(OrderItemEditRequest oiEditRequest);
        //public Task DeleteAsync(int id);
        //public Task<OrderItem> AddAsync(OrderItemAddRequest oiAddRequest);
    }
}
