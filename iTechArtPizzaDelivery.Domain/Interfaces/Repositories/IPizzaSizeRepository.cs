using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPizzasSizesRepository
    {
        public List<PizzaSize> GetAll();

        public PizzaSize GetById(int id);
    }
}
