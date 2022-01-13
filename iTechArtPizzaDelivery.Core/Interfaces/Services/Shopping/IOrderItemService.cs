using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetItemsByOrderIdAsync(int id);
        Task<OrderItem> EditItemByIdAsync(OrderItemEditRequest request);
        Task DeleteItemByIdAsync(int id);
        Task<OrderItem> AddAsync(OrderItemAddRequest request);
    }
}
