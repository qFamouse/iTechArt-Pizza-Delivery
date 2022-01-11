using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class PizzaConstructionService : IPizzaConstructionService
    {
        private readonly IPizzaSizeRepository _pizzaSizeRepository;
        private readonly IPizzaIngredientRepository _pizzaIngredientRepository;

        public PizzaConstructionService(IPizzaSizeRepository pizzaSizeRepository,
            IPizzaIngredientRepository pizzaIngredientRepository)
        {
            _pizzaSizeRepository = pizzaSizeRepository ??
                                   throw new ArgumentNullException(nameof(pizzaSizeRepository), "Interface is null");

            _pizzaIngredientRepository = pizzaIngredientRepository ??
                                    throw new ArgumentNullException(nameof(pizzaSizeRepository), "Interface is null");
        }

        public async Task<PizzaSize> AddAsync(PizzaSizeAddRequest request)
        {
            return await _pizzaSizeRepository.AddAsync(request);
        }

        public async Task<PizzaSize> AddIngredientAsync(PizzaIngredientBindRequest request)
        {
            var newPizzaIngredient = await _pizzaIngredientRepository.AddAsync(request);

            return await GetByIdAsync(newPizzaIngredient.PizzaSizeId);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _pizzaSizeRepository.DeleteAsync(id);

        }

        public async Task<List<PizzaSize>> GetAllAsync()
        {
            return await _pizzaSizeRepository.GetAllAsync();
        }

        public async Task<PizzaSize> GetByIdAsync(int id)
        {
            return await _pizzaSizeRepository.GetDetailByIdAsync(id);
        }
    }
}
