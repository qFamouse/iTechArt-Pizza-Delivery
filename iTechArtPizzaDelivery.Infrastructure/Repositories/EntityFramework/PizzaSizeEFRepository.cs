using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests;
using iTechArtPizzaDelivery.Core.Requests.PizzaSize;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PizzaSizeEFRepository : BaseEFRepository, IPizzaSizeRepository
    {
        public PizzaSizeEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<List<PizzaSize>> GetAllAsync()
        {
            return await _dbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .Include(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .ToListAsync();
        }

        public async Task<PizzaSize> GetByIdAsync(int id)
        {
            return await _dbContext.PizzasSizes
                .SingleAsync(ps => ps.Id == id);
        }

        public async Task<PizzaSize> GetDetailByIdAsync(int id)
        {
            return await _dbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .Include(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .SingleAsync(ps => ps.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var pizza = await _dbContext.PizzasSizes.FirstOrDefaultAsync(ps => ps.Id == id);
            _dbContext.PizzasSizes.Remove(pizza);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PizzaSize> AddAsync(PizzaSizeAddRequest request)
        {
            // Mapping
            var pizzaSize = _mapper.Map<PizzaSize>(request);
            pizzaSize.Pizza = await _dbContext.Pizzas.SingleAsync(p => p.Id == request.PizzaId);
            pizzaSize.Size = await _dbContext.Sizes.SingleAsync(s => s.Id == request.SizeId);
            // Adding
            await _dbContext.PizzasSizes.AddAsync(pizzaSize);
            await _dbContext.SaveChangesAsync();
            return pizzaSize;
        }
    }
}
