using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Size;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface ISizeRepository
    {
        Task<List<Size>> GetAllAsync();
        Task<Size> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<Size> AddAsync(SizeAddRequest request);
    }
}
