using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PizzaIngredientRepository : BaseRepository<PizzaIngredient>, IPizzaIngredientRepository
    {
        public PizzaIngredientRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<PizzaIngredient> AddAsync(PizzaIngredientBindRequest request)
        {
            // Mapping
            var pizzaIngredient = Mapper.Map<PizzaIngredient>(request);
            //pizzaIngredient.Ingredient =
            //    await DbContext.Ingredients.SingleAsync(i => i.Id == request.IngredientId);
            //pizzaIngredient.PizzaSize =
            //    await DbContext.PizzasSizes.SingleAsync(i => i.Id == request.PizzaSizeId);

            pizzaIngredient.IngredientId = request.IngredientId;
            pizzaIngredient.PizzaSizeId = request.PizzaSizeId;
            // Adding
            await DbContext.PizzaIngredients.AddAsync(pizzaIngredient);
            await DbContext.SaveChangesAsync();
            return pizzaIngredient;
        }

        public async Task<List<PizzaIngredient>> GetAllAsync()
        {
            return await DbContext.PizzaIngredients
                .Include(pi => pi.PizzaSize)
                .Include(pi => pi.Ingredient)
                .ToListAsync();
        }
    }
}
