using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IPizzasService
    {
        public List<Pizza> GetAll();
        public Pizza GetById(int id);
        public bool Add(Pizza pizza);
    }
}
