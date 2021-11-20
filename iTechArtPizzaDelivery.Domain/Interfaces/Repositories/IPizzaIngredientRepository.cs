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
        #region Getters

        public Task<List<PizzaIngredient>> GetAllAsync();

        #endregion

        public Task<PizzaIngredient> AddAsync(PizzaIngredientBindRequest pizzaIngredientAddRequest);
    }
}
