using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;

namespace iTechArtPizzaDelivery.Domain.Services
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

        public async Task<Pizza> AddAsync(Pizza pizza)
        {
            return await _pizzaRepository.AddAsync(pizza);
        }
    }
}
