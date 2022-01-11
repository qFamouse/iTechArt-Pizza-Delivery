using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
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
