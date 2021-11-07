using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IPizzasSizesService
    {
        public Task<List<PizzaSize>> GetAllAsync();
        public Task<PizzaSize> GetByIdAsync(int id);
        public Task DeleteAsync(int id);
    }
}
