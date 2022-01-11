using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Delivery;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    public interface IDeliveriesService
    {
        Task<List<Delivery>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Delivery> AddAsync(DeliveryAddRequest request);
    }
}
