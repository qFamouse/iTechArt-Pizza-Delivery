using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Size;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Components
{
    public interface ISizeService
    {
        Task<List<Size>> GetAllAsync();
        Task<Size> GetByIdAsync(int id);
        Task<Size> InsertAsync(SizeInsertRequest request);
        Task DeleteByIdAsync(int id);
        Task<Size> UpdateByIdAsync(int id, SizeUpdateRequest request);

    }
}
