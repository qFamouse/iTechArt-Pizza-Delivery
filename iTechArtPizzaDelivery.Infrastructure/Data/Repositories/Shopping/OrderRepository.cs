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

        public async Task<List<Order>> GetAllAsync()
        {
            return await DbContext.Orders
                .Include(o => o.Promocode)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await DbContext.Orders
                .SingleAsync(o => o.Id == id);
        }

        public async Task<Order> GetDetailByIdAsync(int id)
        {
            return await DbContext.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Promocode)
                .SingleAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetDetailedOrdersAsync(OrderQuery query)
        {
            return await GetByQuery(query)
                .Include(o => o.OrderItems)
                .Include(o => o.Promocode)
                .ToListAsync();
        }

        public async Task<Order> GetDetailedOrderAsync(OrderQuery query)
        {
            return await GetByQuery(query)
                .Include(o => o.OrderItems)
                .Include(o => o.Promocode)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var order = await DbContext.Orders
                .SingleAsync(o => o.Id == id);
            DbContext.Orders.Remove(order);
            await DbContext.SaveChangesAsync();
        }

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

        public async Task<Order> AddAsync(Order order)
        {
            await DbContext.Orders.AddAsync(order);
            await DbContext.SaveChangesAsync();
            return order;
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

    }
}
