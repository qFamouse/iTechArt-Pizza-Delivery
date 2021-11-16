using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Order;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllAsync();
        public Task SaveChangesAsync();
        public Task<Order> GetOrderById(int id);
        public Task<Promocode> GetPromocodeByCode(string code);
    }
}
