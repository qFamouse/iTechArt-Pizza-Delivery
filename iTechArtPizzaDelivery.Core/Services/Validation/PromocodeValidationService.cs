using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;

namespace iTechArtPizzaDelivery.Core.Services.Validation
{
    public class PromocodeValidationService : IPromocodeValidationService
    {
        private readonly IPromocodeRepository _promocodeRepository;

        public PromocodeValidationService(IPromocodeRepository promocodeRepository)
        {
            _promocodeRepository = promocodeRepository ?? throw new ArgumentNullException(nameof(promocodeRepository));
        }

        public async Task PromocodeIsExists(string code)
        {
            if (!await _promocodeRepository.IsExistingCode(code))
            {
                throw new HttpStatusCodeException(404, "Promocode not found");
            }
        }

        public void PromocodeIsValid(Promocode code)
        {
            if (code.StartDate > DateTime.Now)
            {
                throw new HttpStatusCodeException(400, "Promocode has no started working");
            }

            if (code.EndDate < DateTime.Now)
            {
                throw new HttpStatusCodeException(400, "Promocode has expired");
            }
        }
    }
}
