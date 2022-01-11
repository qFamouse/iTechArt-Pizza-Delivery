using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Size;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface ISizesService
    {
        Task<List<Size>> GetAllAsync();
        Task<Size> GetByIdAsync(int id);
        Task<Size> AddAsync(SizeAddRequest request);
        Task DeleteAsync(int id);
    }
}
