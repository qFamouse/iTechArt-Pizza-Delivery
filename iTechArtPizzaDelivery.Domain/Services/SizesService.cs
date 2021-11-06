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

        public Size Add(Size size)
        {
            return _sizeRepository.Add(size);
        }

        public List<Size> GetAll()
        {
            return _sizeRepository.GetAll();
        }

        public Size GetById(int id)
        {
            return _sizeRepository.GetById(id);
        }
    }
}
