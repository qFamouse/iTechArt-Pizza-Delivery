using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Order;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetDetailByIdAsync(int id);
        Task AttachPromocode(OrderAttachPromocodeRequest request);
        Task ProcessOrder();
    }
}
