using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Views;

namespace iTechArtPizzaDelivery.Core.Services.Shopping
{
    public class AnalyticalService : IAnalyticalService
    {
        private readonly IAnalyticalRepository _analyticalRepository;
        private readonly IPizzaSizeRepository _pizzaSizeRepository;
        private readonly IPizzaSizeValidationService _pizzaSizeValidationService;

        public AnalyticalService(IAnalyticalRepository analyticalRepository, IPizzaSizeRepository pizzaSizeRepository, IPizzaSizeValidationService pizzaSizeValidationService)
        {
            _analyticalRepository = analyticalRepository;
            _pizzaSizeRepository = pizzaSizeRepository;
            _pizzaSizeValidationService = pizzaSizeValidationService;
        }

        public async Task<BestPizzaSizeView> GetBestSellingPizzaByMonthAsync(int month)
        {
            if (month is < 1 or > 12)
            {
                throw new HttpStatusCodeException(400, "Invalid month");
            }

            var bestPizzaView = await _analyticalRepository.GetBestSellingPizzaByMonthAsync(month);

            if (bestPizzaView is null)
            {
                throw new HttpStatusCodeException(404, "No better pizza was found in a given month"); // TODO: Maybe change to 204?
            }

            bestPizzaView.PizzaSize = await _pizzaSizeRepository.GetDetailByIdAsync(bestPizzaView.PizzaSize.Id);

            return bestPizzaView;
        }

        public Task<List<User>> GetRegularCustomersAsync()
        {
            return _analyticalRepository.GetRegularCustomersAsync();
        }
    }
}