using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetItemsByOrderIdAsync(int id);
        Task<OrderItem> EditItemByIdAsync(OrderItemEditRequest request);
        Task DeleteItemByIdAsync(int id);
        Task<OrderItem> AddAsync(OrderItemAddRequest request);
    }
}
