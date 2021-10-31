using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class PizzasService : IPizzasService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzasService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository ??
                               throw new ArgumentNullException(nameof(pizzaRepository), "Interface is null");
        }

        public List<Pizza> GetAll()
        {
            return _pizzaRepository.GetAll();
        }

        public Pizza GetById(int id)
        {
            return _pizzaRepository.GetById(id);
        }

        public bool Add(Pizza pizza)
        {
            return _pizzaRepository.Add(pizza);
        }
    }
}
