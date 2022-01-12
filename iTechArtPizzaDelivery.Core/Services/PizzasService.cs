using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Requests.Pizza;

namespace iTechArtPizzaDelivery.Core.Services
{
    public class PizzasService : IPizzasService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzasService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository ??
                               throw new ArgumentNullException(nameof(pizzaRepository), "Interface is null");
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _pizzaRepository.GetAllAsync();
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            return await _pizzaRepository.GetByIdAsync(id);
        }

        public async Task<Pizza> AddAsync(PizzaAddRequest request)
        {
            return await _pizzaRepository.AddAsync(request);
        }

        public async Task DeleteAsync(int id)
        {
            await _pizzaRepository.DeleteAsync(id);
        }
    }
}
