using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.PizzaSize;
using iTechArtPizzaDelivery.Core.Requests;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IPizzaSizeRepository
    {
        Task<List<PizzaSize>> GetAllAsync();
        Task<PizzaSize> GetDetailByIdAsync(int id);
        Task<PizzaSize> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<PizzaSize> AddAsync(PizzaSizeAddRequest request);

    }
}
