using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Requests;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;

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
                                     throw new ArgumentNullException(nameof(pizzasSizesRepository), "Interface is null");
        }
        /// <summary>
        /// Call from init interface method GetAll
        /// </summary>
        /// <returns>All initialized PizzaSize</returns>
        public async Task<List<PizzaSize>> GetAllAsync()
        {
            return await _pizzasSizesRepository.GetAllAsync();
        }

        public async Task<PizzaSize> GetDetailByIdAsync(int id)
        {
            return await _pizzasSizesRepository.GetDetailByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _pizzasSizesRepository.DeleteAsync(id);
        }

        public async Task<PizzaSize> AddAsync(PizzaSizeAddRequest psAddRequest)
        {
            return await _pizzasSizesRepository.AddAsync(psAddRequest);
        }
    }
}
