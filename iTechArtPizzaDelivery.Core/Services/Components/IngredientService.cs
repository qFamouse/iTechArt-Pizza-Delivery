using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.Ingredient;

namespace iTechArtPizzaDelivery.Core.Services.Components
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IIngredientValidationService _ingredientsValidationService;
        private readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredientRepository,
            IIngredientValidationService ingredientsValidationService, IMapper mapper)
        {
            _ingredientRepository =
                ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
            _ingredientsValidationService = ingredientsValidationService ??
                                            throw new ArgumentNullException(nameof(ingredientsValidationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _ingredientRepository.GetByIdAsync(id) ??
                   throw new HttpStatusCodeException(404, "Ingredient not found");
        }

        public async Task<Ingredient> AddAsync(IngredientInsertRequest request)
        {
            var ingredient = _mapper.Map<Ingredient>(request);
            await _ingredientRepository.InsertAsync(ingredient);
            await _ingredientRepository.Save();
            return ingredient;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _ingredientsValidationService.IngredientExistsAsync(id);
            await _ingredientRepository.DeleteByIdAsync(id);
            await _ingredientRepository.Save();
        }

        public async Task<Ingredient> UpdateByIdAsync(int id, IngredientUpdateRequest request)
        {
            await _ingredientsValidationService.IngredientExistsAsync(id);
            var ingredient = _mapper.Map<Ingredient>(request);
            ingredient.Id = id;

            _ingredientRepository.Update(ingredient);
            await _ingredientRepository.Save();

            return ingredient;
        }
    }
}
