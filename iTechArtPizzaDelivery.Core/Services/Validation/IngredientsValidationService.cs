using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;

namespace iTechArtPizzaDelivery.Core.Services.Validation
{
    public class IngredientsValidationService : IIngredientsValidationService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientsValidationService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository =
                ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
        }

        public async Task IngredientExistsAsync(int id)
        {
            if (!await _ingredientRepository.IsExists(id))
            {
                throw new HttpStatusCodeException(404, "Ingredient not found");
            }
        }
    }
}
