using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PizzaIngredientEFRepository : IPizzaIngredientRepository
    {
        #region Private Fields

        private readonly PizzaDeliveryContext _dbContext;

        #endregion

        #region Constructors
        public PizzaIngredientEFRepository(PizzaDeliveryContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context), "Context is null");
        }

        #endregion
        public async Task<PizzaIngredient> AddAsync(PizzaIngredientAddRequest pizzaIngredientAddRequest)
        {
            var pizzaIngredient = new PizzaIngredient
            {
                Weight = pizzaIngredientAddRequest.Weight
            };

            pizzaIngredient.Ingredient =
                await _dbContext.Ingredients.SingleAsync(i => i.Id == pizzaIngredientAddRequest.IngredientId);
            pizzaIngredient.PizzaSize =
                await _dbContext.PizzasSizes.SingleAsync(i => i.Id == pizzaIngredientAddRequest.PizzaSizeId);

            await _dbContext.PizzaIngredients.AddAsync(pizzaIngredient);
            await _dbContext.SaveChangesAsync();
            return pizzaIngredient;
        }

        public async Task<List<PizzaIngredient>> GetAllAsync()
        {
            return await _dbContext.PizzaIngredients
                .Include(pi => pi.PizzaSize)
                .Include(pi => pi.Ingredient)
                .ToListAsync();
        }
    }
}
