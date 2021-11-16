using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Requests.Order;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

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

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _dbContext.Orders
                .SingleAsync(o => o.Id == id);
        }

        public async Task<Promocode> GetPromocodeByCode(string code)
        {
            return await _dbContext.Promocodes
                .SingleAsync(p => p.Code == code);
        }
    }
}
