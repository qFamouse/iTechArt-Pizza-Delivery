using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Requests.Ingredient;

namespace iTechArtPizzaDelivery.Core.Services.Components
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientsService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository ??
                                    throw new ArgumentNullException(nameof(ingredientRepository), "Interface is null");
        }

        public async Task<Ingredient> AddAsync(IngredientAddRequest request)
        {
            return await _ingredientRepository.AddAsync(request);
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _ingredientRepository.GetByIdAsync(id);
        }
    }
}
