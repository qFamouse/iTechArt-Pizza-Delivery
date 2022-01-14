using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Queries;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Shopping
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) {}

        public async Task<Order> GetDetailByIdAsync(int id)
        {
            return await DbContext.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Payment)
                .Include(o => o.Delivery)
                .Include(o => o.Promocode)
                .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetAllDetailedByQueryAsync(OrderQuery query)
        {
            return await GetByQuery(query)
                .Include(o => o.OrderItems)
                .Include(o => o.Promocode)
                .ToListAsync();
        }

        public async Task<Order> GetDetailedByQueryAsync(OrderQuery query)
        {
            return await GetByQuery(query)
                .Include(o => o.OrderItems)
                .Include(o => o.Promocode)
                .FirstOrDefaultAsync();
        }

        public async Task<Order> GetByQueryAsync(OrderQuery query)
        {
            return await GetByQuery(query)
                .FirstOrDefaultAsync();
        }

        #region Private Methods

        private IQueryable<Order> GetByQuery(OrderQuery query)
        {
            IQueryable<Order> ordersQuery = DbContext.Orders;

            if (query.OrderId.HasValue)
            {
                ordersQuery = ordersQuery.Where(o => o.Id == query.OrderId);
            }

            if (query.UserId.HasValue)
            {
                ordersQuery = ordersQuery.Where(o => o.UserId == query.UserId);
            }

            if (query.Status.HasValue)
            {
                ordersQuery = ordersQuery.Where(o => o.Status == query.Status);
            }

            return ordersQuery;
        }

        #endregion
    }
}
