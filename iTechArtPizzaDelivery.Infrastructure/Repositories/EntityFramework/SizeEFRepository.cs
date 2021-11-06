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
    public class SizeEFRepository : ISizeRepository
    {
        #region Private Fields

        private readonly PizzaDeliveryContext _dbContext;

        #endregion

        #region Constructors
        public SizeEFRepository(PizzaDeliveryContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context), "Context is null");
        }

        #endregion

        public async Task<Size> AddAsync(Size size)
        {
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
            return await _dbContext.Sizes.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
