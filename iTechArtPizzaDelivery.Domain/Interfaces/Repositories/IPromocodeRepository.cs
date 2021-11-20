using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPromocodeRepository
    {
        #region Getters

        public Task<List<Promocode>> GetAllAsync();
        public Task<Promocode> GetByCode(string code);

        #endregion

    }
}
