using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PizzaEFRepository : IPizzaRepository
    {
        #region Private Fields

        private readonly PizzaDeliveryContext _dbContext;

        #endregion

        #region Constructors
        public PizzaEFRepository(PizzaDeliveryContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context), "Context is null");
        }

        #endregion

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
    }
}
