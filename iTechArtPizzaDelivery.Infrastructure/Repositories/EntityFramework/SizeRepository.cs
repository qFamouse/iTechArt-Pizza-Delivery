using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.Size;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class SizeRepository : BaseRepository<Size>, ISizeRepository
    {
        public SizeRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Size> AddAsync(SizeAddRequest sAddRequest)
        {
            var size = Mapper.Map<Size>(sAddRequest);
            await DbContext.Sizes.AddAsync(size);
            await DbContext.SaveChangesAsync();
            return size;
        }
        public async Task<List<Size>> GetAllAsync()
        {
            return await DbContext.Sizes.ToListAsync();
        }
        public async Task<Size> GetByIdAsync(int id)
        {
            return await DbContext.Sizes.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task DeleteAsync(int id)
        {
            var pizza = await DbContext.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            DbContext.Sizes.Remove(pizza);
            await DbContext.SaveChangesAsync();
        }
    }
}
