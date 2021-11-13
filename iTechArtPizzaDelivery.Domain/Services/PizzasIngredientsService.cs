using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class PizzasIngredientsService : IPizzaIngredientService
    {
        private readonly IPizzaIngredientRepository _ingredientRepository;

        public PizzasIngredientsService(IPizzaIngredientRepository pizzaIngredientRepository)
        {
            _ingredientRepository = pizzaIngredientRepository ??
                                    throw new ArgumentNullException(nameof(pizzaIngredientRepository), "Interface is null");
        }
        public async Task<PizzaIngredient> AddAsync(PizzaIngredientAddRequest piAddRequest)
        {
            return await _ingredientRepository.AddAsync(piAddRequest);
        }

        public async Task<List<PizzaIngredient>> GetAllAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }
    }
}
