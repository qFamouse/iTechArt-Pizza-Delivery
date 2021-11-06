using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPizzaRepository
    {
        public Task<List<Pizza>> GetAllAsync();
        public Task<Pizza> GetByIdAsync(int id);
        public Task<Pizza> AddAsync(Pizza pizza);
    }
}
