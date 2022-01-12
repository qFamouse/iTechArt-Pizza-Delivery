using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Size;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface ISizesService
    {
        Task<List<Size>> GetAllAsync();
        Task<Size> GetByIdAsync(int id);
        Task<Size> AddAsync(SizeAddRequest request);
        Task DeleteAsync(int id);
    }
}
