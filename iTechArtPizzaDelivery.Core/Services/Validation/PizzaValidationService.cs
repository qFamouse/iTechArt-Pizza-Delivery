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
    public class PizzaValidationService : IPizzasValidationService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaValidationService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
        }

        public async Task PizzaExistsAsync(int id)
        {
            if (!await _pizzaRepository.IsExists(id))
            {
                throw new HttpStatusCodeException(404, "Pizza not found");
            }
        }
    }
}
