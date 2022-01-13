using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Promocode;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IPromocodeService
    {
        Task<List<Promocode>> GetAllAsync();
        Task<Promocode> AddAsync(PromocodeAddRequest request);
    }
}
