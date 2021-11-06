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
    public class IngredientEFRepository : IIngredientRepository
    {
        #region Private Fields

        private readonly PizzaDeliveryContext _dbContext;

        #endregion

        #region Constructors
        public IngredientEFRepository(PizzaDeliveryContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context), "Context is null");
        }

        #endregion
        public async Task<Ingredient> AddAsync(Ingredient ingredient)
        {
            await _dbContext.Ingredients.AddAsync(ingredient);
            await _dbContext.SaveChangesAsync();
            return ingredient;
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _dbContext.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _dbContext.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
