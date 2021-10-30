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
    public class PizzaSizeEFRepository : IPizzasSizesRepository
    {
        private readonly PizzaDeliveryContext _context;

        public PizzaSizeEFRepository(PizzaDeliveryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Context is null");
        }
        public List<PizzaSize> GetAll()
        {
            return _context.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .ToList();
        }

        public PizzaSize GetById(int id)
        {
            return _context.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .FirstOrDefault(ps => ps.Id == id);
        }
    }
}
