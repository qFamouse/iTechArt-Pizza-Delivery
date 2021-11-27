using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Queries;
using iTechArtPizzaDelivery.Domain.Requests.Order;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class OrderEFRepository : BaseEFRepository, IOrderRepository
    {
        public OrderEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) {}

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders
                .Include(o => o.Promocode)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbContext.Orders
                .SingleAsync(o => o.Id == id);
        }

        public async Task<Order> GetDetailByIdAsync(int id)
        {
            return await _dbContext.Orders
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
            var order = await _dbContext.Orders
                .SingleAsync(o => o.Id == id);
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<Order> GetByQuery(OrderQuery query)
        {
            IQueryable<Order> ordersQuery = _dbContext.Orders;

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
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
