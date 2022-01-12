using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Size;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface ISizeRepository
    {
        Task<List<Size>> GetAllAsync();
        Task<Size> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<Size> AddAsync(SizeAddRequest request);
    }
}
