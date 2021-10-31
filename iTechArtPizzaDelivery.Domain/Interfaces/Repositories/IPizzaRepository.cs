using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPizzaRepository
    {
        public List<Pizza> GetAll();
        public Pizza GetById(int id);
        public bool Add(Pizza pizza);
    }
}
