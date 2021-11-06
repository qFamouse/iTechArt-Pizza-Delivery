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
    public class PizzaIngredientsService : IPizzaIngredientService
    {
        private readonly IPizzaIngredientRepository _ingredientRepository;

        public PizzaIngredientsService(IPizzaIngredientRepository pizzaIngredientRepository)
        {
            _ingredientRepository = pizzaIngredientRepository ??
                                    throw new ArgumentNullException(nameof(pizzaIngredientRepository), "Interface is null");
        }
        public async Task<PizzaIngredient> AddAsync(PizzaIngredient pizzaIngredient)
        {
            return await _ingredientRepository.AddAsync(pizzaIngredient);
        }

        public async Task<List<PizzaIngredient>> GetAllAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }
    }
}
