using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Pizza;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IPizzasService
    {
        #region Getters

        public Task<List<Pizza>> GetAllAsync();
        public Task<Pizza> GetByIdAsync(int id);

        #endregion

        #region Setters

        public Task DeleteAsync(int id);

        #endregion

        public Task<Pizza> AddAsync(PizzaAddRequest pAddRequest);
    }
}
