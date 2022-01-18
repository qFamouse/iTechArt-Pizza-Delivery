using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Extensions
{
    static class DbSetExtensions
    {
        public static IQueryable<T> ToPageable<T>(this DbSet<T> dbSet, int pageNumber, int pageSize) where T : class
        {
            return dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}