using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Delivery;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IDeliveryRepository
    {
        Task<List<Delivery>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Delivery> AddAsync(DeliveryAddRequest request);
    }
}
