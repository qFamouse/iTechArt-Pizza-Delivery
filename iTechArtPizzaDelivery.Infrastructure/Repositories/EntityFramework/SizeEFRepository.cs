using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;

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

        public Size Add(Size size)
        {
            _dbContext.Sizes.Add(size);
            _dbContext.SaveChanges();
            return size;
        }

        public List<Size> GetAll()
        {
            return _dbContext.Sizes.ToList();
        }

        public Size GetById(int id)
        {
            return _dbContext.Sizes.FirstOrDefault(p => p.Id == id);
        }
    }
}
