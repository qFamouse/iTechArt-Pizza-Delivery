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
    public class PizzasSizesService : IPizzasSizesService
    {
        /// <summary>
        /// Encapsulated interface which we get when we init instance of class
        /// </summary>
        private readonly IPizzasSizesRepository _pizzasSizesRepository;
        /// <summary>
        /// Constructor from which we encapsulate interface
        /// </summary>
        /// <param name="pizzasSizesRepository">_pizzasSizesRepository</param>
        public PizzasSizesService(IPizzasSizesRepository pizzasSizesRepository)
        {
            
            _pizzasSizesRepository = pizzasSizesRepository ?? // If pizzasSizesRepository is null
                                     throw new ArgumentNullException(nameof(pizzasSizesRepository), "Interface pizzasSizesRepository is null");
        }
        /// <summary>
        /// Call from init interface method GetAll
        /// </summary>
        /// <returns>All initialized PizzaSize</returns>
        public async Task<List<PizzaSize>> GetAllAsync()
        {
            return await _pizzasSizesRepository.GetAllAsync();
        }

        public async Task<PizzaSize> GetByIdAsync(int id)
        {
            return await _pizzasSizesRepository.GetByIdAsync(id);
        }
    }
}
