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
        public Task<List<OrderItem>> GetItemsByOrderIdAsync(int orderId);
        public Task<OrderItem> GetOrderItemByIdAsync(int id);
        public Task DeleteById(int id);
        public Task SaveChangesAsync();
        //public Task<OrderItem> EditByIdAsync(OrderItemEditRequest oiEditRequest);
        //public Task DeleteAsync(int id);
        //public Task<OrderItem> AddAsync(OrderItemAddRequest oiAddRequest);
    }
}
