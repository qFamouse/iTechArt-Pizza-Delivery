using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Construction;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Core.Requests.PizzaSize;

namespace iTechArtPizzaDelivery.Core.Services.Construction
{
    public class PizzaConstructionService : IPizzaConstructionService
    {
        private readonly IPizzaSizeRepository _pizzaSizeRepository;
        private readonly IPizzaIngredientRepository _pizzaIngredientRepository;

        private readonly IPizzasValidationService _pizzasValidationService;
        private readonly ISizesValidationService _sizesValidationService;
        private readonly IPizzaSizeValidationService _pizzaSizeValidationService;
        private readonly IIngredientsValidationService _ingredientsValidationService;

        private readonly IMapper _mapper;

        public PizzaConstructionService(IPizzaSizeRepository pizzaSizeRepository,
            IPizzaIngredientRepository pizzaIngredientRepository, IPizzasValidationService pizzasValidationService,
            ISizesValidationService sizesValidationService, IPizzaSizeValidationService pizzaSizeValidationService,
            IIngredientsValidationService ingredientsValidationService, IMapper mapper)
        {
            _pizzaSizeRepository = pizzaSizeRepository ?? throw new ArgumentNullException(nameof(pizzaSizeRepository));
            _pizzaIngredientRepository = pizzaIngredientRepository ??
                                         throw new ArgumentNullException(nameof(pizzaIngredientRepository));
            _pizzasValidationService = pizzasValidationService ??
                                       throw new ArgumentNullException(nameof(pizzasValidationService));
            _sizesValidationService =
                sizesValidationService ?? throw new ArgumentNullException(nameof(sizesValidationService));
            _pizzaSizeValidationService = pizzaSizeValidationService ??
                                          throw new ArgumentNullException(nameof(pizzaSizeValidationService));
            _ingredientsValidationService = ingredientsValidationService ??
                                            throw new ArgumentNullException(nameof(ingredientsValidationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PizzaSize> InsertAsync(PizzaSizeAddRequest request)
        {
            await _pizzasValidationService.PizzaExistsAsync(request.PizzaId);
            await _sizesValidationService.SizeExistsAsync(request.SizeId);

            var pizzaSize = _mapper.Map<PizzaSize>(request);
            await _pizzaSizeRepository.InsertAsync(pizzaSize);
            await _pizzaSizeRepository.Save();

            return await GetDetailByIdAsync(pizzaSize.Id);
        }

        public async Task<PizzaSize> InsertIngredientAsync(PizzaIngredientRequest request)
        {
            await _pizzaSizeValidationService.PizzaSizeExistsAsync(request.PizzaSizeId);
            await _ingredientsValidationService.IngredientExistsAsync(request.IngredientId);

            var pizzaIngredient = _mapper.Map<PizzaIngredient>(request);
            await _pizzaIngredientRepository.InsertAsync(pizzaIngredient);
            await _pizzaIngredientRepository.Save();

            return await GetDetailByIdAsync(request.PizzaSizeId);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _pizzaSizeValidationService.PizzaSizeExistsAsync(id);
            await _pizzaSizeRepository.DeleteByIdAsync(id);
            await _pizzaSizeRepository.Save();
        }

        public async Task<List<PizzaSize>> GetAllAsync()
        {
            return await _pizzaSizeRepository.GetAllAsync();
        }

        public async Task<PizzaSize> GetDetailByIdAsync(int id)
        {
            return await _pizzaSizeRepository.GetDetailByIdAsync(id) ??
                   throw new HttpStatusCodeException(404, "Pizza not found");
        }
    }
}