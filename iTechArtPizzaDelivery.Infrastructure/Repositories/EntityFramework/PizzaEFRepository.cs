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
    public class PizzaEFRepository : IPizzaRepository
    {
        #region Private Fields

        private readonly PizzaDeliveryContext _dbContext;

        #endregion

        #region Constructors
        public PizzaEFRepository(PizzaDeliveryContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context), "Context is null");
        }

        #endregion

        public Pizza Add(Pizza pizza)
        {
            _dbContext.Pizzas.Add(pizza);
            _dbContext.SaveChanges();
            return pizza;
        }

        public List<Pizza> GetAll()
        {
            return _dbContext.Pizzas.ToList();

        }

        public Pizza GetById(int id)
        {
            return _dbContext.Pizzas.FirstOrDefault(p => p.Id == id);

        }
    }
}
