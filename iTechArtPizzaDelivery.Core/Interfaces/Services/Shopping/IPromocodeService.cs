using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Promocode;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IPromocodeService
    {
        Task<List<Promocode>> GetAllAsync();
        Task<Promocode> GetByCodeAsync();
        Task<Promocode> AddAsync(PromocodeAddRequest request);
        Task DeleteByIdAsync(int id);
        Task<Promocode> UpdateByIdAsync(int id, PromocodeUpdateRequest request);
    }
}