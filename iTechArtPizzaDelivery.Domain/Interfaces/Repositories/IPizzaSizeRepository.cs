using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPizzasSizesRepository
    {
        public Task<List<PizzaSize>> GetAllAsync();
        public Task<PizzaSize> GetByIdAsync(int id);
        public Task DeleteAsync(int id);
        public Task<PizzaSize> AddAsync(PizzaSizeAddRequest pizzaSizeAddRequest);
    }
}
