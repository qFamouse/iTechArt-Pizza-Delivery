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
        Task<List<Order>> GetAllAsync();
        Task<Order> GetDetailByIdAsync(int id);
        Task AttachPromocode(OrderAttachPromocodeRequest request);
        Task ProcessOrder();
    }
}
