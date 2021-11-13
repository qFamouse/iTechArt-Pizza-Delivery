using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Requests.Size;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class SizeEFRepository : BaseEFRepository, ISizeRepository
    {
        public SizeEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Size> AddAsync(SizeAddRequest sAddRequest)
        {
            var size = _mapper.Map<Size>(sAddRequest);
            await _dbContext.Sizes.AddAsync(size);
            await _dbContext.SaveChangesAsync();
            return size;
        }
        public async Task<List<Size>> GetAllAsync()
        {
            return await _dbContext.Sizes.ToListAsync();
        }
        public async Task<Size> GetByIdAsync(int id)
        {
            return await _dbContext.Sizes.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task DeleteAsync(int id)
        {
            var pizza = await _dbContext.Sizes.FirstOrDefaultAsync(s => s.Id == id);
            _dbContext.Sizes.Remove(pizza);
            await _dbContext.SaveChangesAsync();
        }
    }
}
