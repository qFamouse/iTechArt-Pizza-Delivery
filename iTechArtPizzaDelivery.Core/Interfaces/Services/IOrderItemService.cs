using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetItemsByOrderIdAsync(int id);
        Task<OrderItem> EditItemByIdAsync(OrderItemEditRequest request);
        Task DeleteItemByIdAsync(int id);
        Task<OrderItem> AddAsync(OrderItemAddRequest request);
    }
}
