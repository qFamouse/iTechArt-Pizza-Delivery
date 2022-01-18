using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetAllByPageAsync(int pageNumber);
        Task<Order> GetDetailByIdAsync(int id);
        Task<Order> GetDetailByUserAsync();
        Task AttachPromocodeAsync(string promocode);
        Task AttachPaymentAsync(int paymentId);
        Task AttachDeliveryAsync(int deliveryId);
        Task ProcessOrderAsync();
    }
}