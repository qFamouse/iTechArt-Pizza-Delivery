using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPizzaIngredientRepository
    {
        Task<List<PizzaIngredient>> GetAllAsync();
        Task<PizzaIngredient> AddAsync(PizzaIngredientBindRequest request);
    }
}
