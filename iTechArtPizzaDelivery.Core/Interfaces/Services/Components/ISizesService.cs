using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Size;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Components
{
    public interface ISizesService
    {
        Task<List<Size>> GetAllAsync();
        Task<Size> GetByIdAsync(int id);
        Task<Size> AddAsync(SizeAddRequest request);
        Task DeleteAsync(int id);
    }
}
