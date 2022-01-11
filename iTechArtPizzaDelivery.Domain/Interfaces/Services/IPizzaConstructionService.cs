using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IPizzaConstructionService
    {
        Task<List<PizzaSize>> GetAllAsync();
        Task<PizzaSize> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task<PizzaSize> AddIngredientAsync(PizzaIngredientBindRequest request);
        Task<PizzaSize> AddAsync(PizzaSizeAddRequest request);
    }
}
