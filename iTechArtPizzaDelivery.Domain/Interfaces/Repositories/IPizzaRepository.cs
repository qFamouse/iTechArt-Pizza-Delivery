using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Pizza;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPizzaRepository
    {
        public Task<List<Pizza>> GetAllAsync();
        public Task<Pizza> GetByIdAsync(int id);
        public Task<Pizza> AddAsync(PizzaAddRequest pAddRequest);
        public Task DeleteAsync(int id);
    }
}
