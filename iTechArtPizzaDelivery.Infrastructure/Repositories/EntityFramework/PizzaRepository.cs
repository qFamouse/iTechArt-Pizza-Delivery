using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.Pizza;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Pizza> AddAsync(PizzaAddRequest request)
        {
            var pizza = Mapper.Map<Pizza>(request);
            await DbContext.Pizzas.AddAsync(pizza);
            await DbContext.SaveChangesAsync();
            return pizza;
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await DbContext.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            return await DbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var pizza = await DbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id);
            DbContext.Pizzas.Remove(pizza);
            await DbContext.SaveChangesAsync();
        }
    }
}