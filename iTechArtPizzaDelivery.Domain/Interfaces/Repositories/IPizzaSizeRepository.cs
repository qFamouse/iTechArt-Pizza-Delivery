using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
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
