using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IPizzasSizesService
    {
        public Task<List<PizzaSize>> GetAllAsync();
        public Task<PizzaSize> GetDetailByIdAsync(int id);
        public Task DeleteAsync(int id);
        public Task<PizzaSize> AddAsync(PizzaSizeAddRequest psAddRequest);
    }
}
