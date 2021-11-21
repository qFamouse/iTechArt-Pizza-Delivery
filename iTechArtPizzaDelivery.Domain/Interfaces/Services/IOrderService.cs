using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Order;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IOrderService
    {
        #region Getters

        public Task<List<Order>> GetAllAsync();
        public Task<Order> GetDetailByIdAsync(int id);

        #endregion

        #region Setters

        public Task AttachPromocode(OrderAttachPromocodeRequest request);

        #endregion
    }
}
