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
    interface IPizzasCartService
    {
        #region Getters

        public Task<List<PizzaSize>> GetAllAsync();
        public Task<PizzaSize> GetByIdAsync(int id);

        #endregion

        #region Setters

        public Task DeleteByIdAsync(int id);
        public Task<PizzaIngredient> BindIngredient(PizzaIngredientBindRequest request);

        #endregion

        public Task<PizzaSize> AddAsync(PizzaSizeAddRequest request);
    }
}
