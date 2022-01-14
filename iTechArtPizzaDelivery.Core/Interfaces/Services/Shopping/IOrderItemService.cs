using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IOrderItemService
    {
        Task<OrderItem> AddAsync(OrderItemInsertRequest request);
        Task DeleteByIdAsync(int orderItemId);
        Task<OrderItem> UpdateByIdAsync(int orderItemId, OrderItemUpdateRequest request);
        
        Task<List<OrderItem>> GetAllAsync();
    }
}
