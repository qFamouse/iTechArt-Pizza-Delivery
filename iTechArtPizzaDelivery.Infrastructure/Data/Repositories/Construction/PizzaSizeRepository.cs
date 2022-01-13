using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.PizzaSize;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Construction
{
    public class PizzaSizeRepository : BaseRepository<PizzaSize>, IPizzaSizeRepository
    {
        public PizzaSizeRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<List<PizzaSize>> GetAllAsync()
        {
            return await DbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .Include(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .ToListAsync();
        }

        public async Task<PizzaSize> GetByIdAsync(int id)
        {
            return await DbContext.PizzasSizes
                .SingleAsync(ps => ps.Id == id);
        }

        public async Task<PizzaSize> GetDetailByIdAsync(int id)
        {
            return await DbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .Include(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .SingleAsync(ps => ps.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var pizza = await DbContext.PizzasSizes.FirstOrDefaultAsync(ps => ps.Id == id);
            DbContext.PizzasSizes.Remove(pizza);
            await DbContext.SaveChangesAsync();
        }

        public async Task<PizzaSize> AddAsync(PizzaSizeAddRequest request)
        {
            // Mapping
            var pizzaSize = Mapper.Map<PizzaSize>(request);
            pizzaSize.Pizza = await DbContext.Pizzas.SingleAsync(p => p.Id == request.PizzaId);
            pizzaSize.Size = await DbContext.Sizes.SingleAsync(s => s.Id == request.SizeId);
            // Adding
            await DbContext.PizzasSizes.AddAsync(pizzaSize);
            await DbContext.SaveChangesAsync();
            return pizzaSize;
        }
    }
}
