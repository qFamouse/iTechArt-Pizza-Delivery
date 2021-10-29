using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IPizzasSizesService
    {
        public List<PizzaSize> GetAll();

        public PizzaSize GetById(int id);
    }
}
