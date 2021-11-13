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
        public Task<List<PizzaIngredient>> GetAllAsync();
        public Task<PizzaIngredient> AddAsync(PizzaIngredientAddRequest pizzaIngredientAddRequest);
    }
}
