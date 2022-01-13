using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T: class, IEntity
    {
        protected PizzaDeliveryContext DbContext { get; }
        protected IMapper Mapper { get; }

        private readonly DbSet<T> _dbSet;

        public BaseRepository(PizzaDeliveryContext context, IMapper mapper)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context), "DB Context is null");
            _dbSet = context.Set<T>() ?? throw new ArgumentNullException(nameof(T), "DbSet is null");
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}