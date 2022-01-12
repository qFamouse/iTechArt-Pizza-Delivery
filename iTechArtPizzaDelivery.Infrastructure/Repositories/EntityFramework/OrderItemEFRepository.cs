using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class OrderItemEFRepository : BaseEFRepository, IOrderItemRepository
    {
        public OrderItemEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<OrderItem> Add(OrderItem orderItem)
        {
            await _dbContext.OrderItems.AddAsync(orderItem);
            await _dbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task DeleteById(int id)
        {
            _dbContext.Remove(await _dbContext.OrderItems.
                SingleAsync(oi => oi.Id == id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<OrderItem>> GetAllByOrderIdAsync(int id)
        {
            return await _dbContext.OrderItems
                .Include(oi => oi.PizzaSize)
                .ThenInclude(ps => ps.Pizza)
                .Include(oi => oi.PizzaSize)
                .ThenInclude(ps => ps.Size)
                .Include(oi => oi.PizzaSize)
                .ThenInclude(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .Where(oi => oi.Order.Id == id)
                .ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await _dbContext.OrderItems
                .Include(oi => oi.PizzaSize)
                .ThenInclude(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .SingleAsync(oi => oi.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
