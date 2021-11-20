using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPizzaSizeRepository
    {
        #region Getters

        public Task<List<PizzaSize>> GetAllAsync();
        public Task<PizzaSize> GetDetailByIdAsync(int id);

        #endregion

        #region Setters

        public Task DeleteAsync(int id);

        #endregion

        public Task<PizzaSize> AddAsync(PizzaSizeAddRequest psAddRequest);
    }
}
