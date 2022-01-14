using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetDetailByIdAsync(int id);
        Task AttachPromocodeAsync(string promocode);
        Task AttachPaymentAsync(int paymentId);
        Task AttachDeliveryAsync(int deliveryId);
        Task ProcessOrderAsync();
    }
}