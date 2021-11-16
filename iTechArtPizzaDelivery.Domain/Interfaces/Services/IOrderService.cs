using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Order;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IOrderService
    {
        public Task<List<Order>> GetAllAsync();
        public Task AddPromocode(OrderAddPromocodeRequest request);
    }
}
