using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IOrderItemService
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<OrderItem> AddAsync(OrderItemAddRequest request);
        Task DeleteByIdAsync(int id);
        Task<OrderItem> UpdateByIdAsync(int id, OrderItemEditRequest request);
        Task<List<OrderItem>> GetItemsByOrderIdAsync(int id);
    }
}
