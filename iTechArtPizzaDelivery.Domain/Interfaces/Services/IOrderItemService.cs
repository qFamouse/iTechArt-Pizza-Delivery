using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IOrderItemService
    {
        public Task<List<OrderItem>> GetItemsByOrderIdAsync(int id);
        public Task<OrderItem> EditItemByIdAsync(OrderItemEditRequest request);
        public Task DeleteItemByIdAsync(int id);
        public void RecalculateItem(OrderItem orderItem);
    }
}
