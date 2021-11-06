using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class SizesService : ISizesService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizesService(ISizeRepository sizeRepository)
        {

            _sizeRepository = sizeRepository ?? // If pizzasSizesRepository is null
                              throw new ArgumentNullException(nameof(sizeRepository), "Interface is null");
        }

        public async Task<Size> AddAsync(Size size)
        {
            return await _sizeRepository.AddAsync(size);
        }

        public async Task<List<Size>> GetAllAsync()
        {
            return await _sizeRepository.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await _sizeRepository.GetByIdAsync(id);
        }
    }
}
