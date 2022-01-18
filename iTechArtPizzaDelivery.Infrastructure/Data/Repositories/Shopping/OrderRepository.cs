using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Configurations;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Queries;
using iTechArtPizzaDelivery.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Shopping
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly PaginationConfiguration _paginationConfiguration;

        public OrderRepository(PizzaDeliveryContext context, IMapper mapper,
            IOptions<PaginationConfiguration> paginationConfiguration) : base(context, mapper)
        {
            _paginationConfiguration = paginationConfiguration.Value ??
                                       throw new NullReferenceException(nameof(paginationConfiguration));
        }

        public Task<List<Order>> GetAllByPageAsync(int pageNumber)
        {
            return DbContext.Orders.ToPageable(pageNumber, _paginationConfiguration.DefaultPageSize).ToListAsync();
        }

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

        public async Task<Order> GetDetailByQueryAsync(OrderQuery query)
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
