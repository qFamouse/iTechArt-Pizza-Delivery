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
    public class PizzaSizeValidationService : IPizzaSizeValidationService
    {
        private readonly IPizzaSizeRepository _pizzaSizeRepository;

        public PizzaSizeValidationService(IPizzaSizeRepository pizzaSizeRepository)
        {
            _pizzaSizeRepository = pizzaSizeRepository ?? throw new ArgumentNullException(nameof(pizzaSizeRepository));
        }

        public async Task PizzaSizeExistsAsync(int id)
        {
            if (!await _pizzaSizeRepository.IsExists(id))
            {
                throw new HttpStatusCodeException(404, "Pizza not found");
            }
        }
    }
}
