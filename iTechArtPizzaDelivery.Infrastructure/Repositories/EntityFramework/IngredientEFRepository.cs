using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.Ingredient;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class IngredientEFRepository : BaseEFRepository, IIngredientRepository
    {
        public IngredientEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Ingredient> AddAsync(IngredientAddRequest iAddRequest)
        {
            var ingredient = _mapper.Map<Ingredient>(iAddRequest);
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
