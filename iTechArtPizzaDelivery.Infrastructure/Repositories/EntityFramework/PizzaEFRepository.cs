using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PizzaEFRepository : BaseEFRepository, IPizzaRepository
    {
        public PizzaEFRepository(PizzaDeliveryContext context) : base(context) { }

        public async Task<Pizza> AddAsync(Pizza pizza)
        {
            await _dbContext.Pizzas.AddAsync(pizza);
            await _dbContext.SaveChangesAsync();
            return pizza;
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _dbContext.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            return await _dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var pizza = await _dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            _dbContext.Pizzas.Remove(pizza);
            await _dbContext.SaveChangesAsync();
        }
    }
}