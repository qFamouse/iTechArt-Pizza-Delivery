using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Delivery;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IDeliveriesService
    {
        Task<List<Delivery>> GetAllAsync();
        Task<Delivery> GetByIdAsync(int id);
        Task<Delivery> AddAsync(DeliveryAddRequest request);
        Task DeleteByIdAsync(int id);
        Task<Delivery> UpdateByIdAsync(int id, DeliveryUpdateRequest request);
    }
}
