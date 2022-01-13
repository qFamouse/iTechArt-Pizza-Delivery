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

        public async Task<PizzaSize> GetDetailByIdAsync(int id)
        {
            return await DbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .Include(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .SingleAsync(ps => ps.Id == id);
        }
    }
}
