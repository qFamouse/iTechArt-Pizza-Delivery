using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Core.Requests.PizzaSize;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IPizzaConstructionService
    {
        Task<List<PizzaSize>> GetAllAsync();
        Task<PizzaSize> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task<PizzaSize> AddIngredientAsync(PizzaIngredientBindRequest request);
        Task<PizzaSize> AddAsync(PizzaSizeAddRequest request);
    }
}
