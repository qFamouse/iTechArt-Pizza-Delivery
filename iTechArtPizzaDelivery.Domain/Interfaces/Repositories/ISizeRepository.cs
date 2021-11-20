using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Size;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface ISizeRepository
    {
        #region Getters

        public Task<List<Size>> GetAllAsync();
        public Task<Size> GetByIdAsync(int id);

        #endregion

        #region Setters

        public Task DeleteAsync(int id);

        #endregion

        public Task<Size> AddAsync(SizeAddRequest sAddRequest);
    }
}
