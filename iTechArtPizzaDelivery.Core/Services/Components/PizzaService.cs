using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.Pizza;

namespace iTechArtPizzaDelivery.Core.Services.Components
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzasValidationService _pizzasValidationService;
        private readonly IMapper _mapper;
        public PizzaService(IPizzaRepository pizzaRepository, IPizzasValidationService pizzasValidationService,
            IMapper mapper)
        {
            _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
            _pizzasValidationService = pizzasValidationService ??
                                       throw new ArgumentNullException(nameof(pizzasValidationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _pizzaRepository.GetAllAsync();
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            return await _pizzaRepository.GetByIdAsync(id) ??
                   throw new HttpStatusCodeException(404, "Pizza not found");
        }

        public async Task<Pizza> AddAsync(PizzaInsertRequest request)
        {
            var pizza = _mapper.Map<Pizza>(request);
            await _pizzaRepository.InsertAsync(pizza);
            await _pizzaRepository.Save();
            return pizza;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _pizzasValidationService.PizzaExistsAsync(id);
            await _pizzaRepository.DeleteByIdAsync(id);
            await _pizzaRepository.Save();
        }

        public async Task<Pizza> UpdateByIdAsync(int id, PizzaUpdateRequest request)
        {
            await _pizzasValidationService.PizzaExistsAsync(id);
            var pizza = _mapper.Map<Pizza>(request);
            pizza.Id = id;

            _pizzaRepository.Update(pizza);
            await _pizzaRepository.Save();

            return pizza;
        }
    }
}
