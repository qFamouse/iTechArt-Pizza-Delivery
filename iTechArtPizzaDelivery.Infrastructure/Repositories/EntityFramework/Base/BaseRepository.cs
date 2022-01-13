using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T: class
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
            return await _dbSet.FindAsync(id) ?? throw new HttpStatusCodeException(404, "Not found");
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id) ?? throw new HttpStatusCodeException(404, "Not found");
            _dbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            var aa = await DbContext.Entry(entity).GetDatabaseValuesAsync();
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}