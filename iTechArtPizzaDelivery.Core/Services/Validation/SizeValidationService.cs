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
    public class SizeValidationService : ISizesValidationService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeValidationService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository ?? throw new ArgumentNullException(nameof(sizeRepository));
        }

        public async Task SizeExistsAsync(int id)
        {
            if (!await _sizeRepository.IsExists(id))
            {
                throw new HttpStatusCodeException(404, "Size not found");
            }
        }
    }
}
