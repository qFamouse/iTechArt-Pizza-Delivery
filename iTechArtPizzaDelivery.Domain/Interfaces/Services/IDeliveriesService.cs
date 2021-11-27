using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Delivery;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IDeliveriesService
    {
        #region Getters

        public Task<List<Delivery>> GetAllAsync();

        #endregion

        #region Setters

        public Task DeleteByIdAsync(int id);
        public Task<Delivery> AddAsync(DeliveryAddRequest request);

        #endregion
    }
}
