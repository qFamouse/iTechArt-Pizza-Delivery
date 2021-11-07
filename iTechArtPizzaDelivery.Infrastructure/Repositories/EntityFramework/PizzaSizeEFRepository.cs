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
    public class PizzaSizeEFRepository : IPizzasSizesRepository
    {
        #region Private Fields

        private readonly PizzaDeliveryContext _dbContext;

        #endregion

        #region Constructors
        public PizzaSizeEFRepository(PizzaDeliveryContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context), "Context is null");
        }

        #endregion

        public async Task<List<PizzaSize>> GetAllAsync()
        {
            return await _dbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .ToListAsync();
        }

        public async Task<PizzaSize> GetByIdAsync(int id)
        {
            return await _dbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .FirstOrDefaultAsync(ps => ps.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var pizza = await _dbContext.PizzasSizes.FirstOrDefaultAsync(ps => ps.Id == id);
            _dbContext.PizzasSizes.Remove(pizza);
            await _dbContext.SaveChangesAsync();
        }
    }
}
