using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Requests.Size;

namespace iTechArtPizzaDelivery.Core.Services
{
    public class SizesService : ISizesService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizesService(ISizeRepository sizeRepository)
        {

            _sizeRepository = sizeRepository ?? // If pizzasSizesRepository is null
                              throw new ArgumentNullException(nameof(sizeRepository), "Interface is null");
        }

        public async Task<Size> AddAsync(SizeAddRequest request)
        {
            return await _sizeRepository.AddAsync(request);
        }

        public async Task<List<Size>> GetAllAsync()
        {
            return await _sizeRepository.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await _sizeRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _sizeRepository.DeleteAsync(id);
        }
    }
}
