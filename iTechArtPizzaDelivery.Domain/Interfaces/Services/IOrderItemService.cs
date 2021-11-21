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
        #region Getters

        public Task<List<OrderItem>> GetItemsByOrderIdAsync(int id);

        #endregion

        #region Setters

        public Task<OrderItem> EditItemByIdAsync(OrderItemEditRequest request);
        public Task DeleteItemByIdAsync(int id);

        #endregion

        public Task<OrderItem> AddAsync(OrderItemAddRequest request);
    }
}
