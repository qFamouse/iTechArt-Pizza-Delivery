using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.Fakes
{
    public class PizzasSizesFakeRepository : IPizzasSizesRepository
    {
        /// <summary>
        /// Enum for choose pizza size by string
        /// </summary>
        enum eSize
        {
            Small = 0,
            Medium,
            Large
        }
        /// <summary>
        /// Collection with pizza sizes
        /// </summary>
        private static readonly List<Size> _sizes = new List<Size>()
        {
            new Size() {Id = 1, Name = "Small", Diameter = 25},
            new Size() {Id = 2, Name = "Medium", Diameter = 30},
            new Size() {Id = 3, Name = "Large", Diameter = 35}
        };

        private readonly List<PizzaSize> _pizzas = new List<PizzaSize>()
        {
            new PizzaSize
            {
                Id = 1,
                Pizza = new Pizza {Id = 1, Image = "", Name = "Pepperoni", Description = "Wonderful pizza for all family"},
                Size = _sizes[(int)eSize.Small],
                Price = 4,
                Weight = 470
            },
            new PizzaSize
            {
                Id = 2,
                Pizza = new Pizza {Id = 1, Image = "", Name = "Pepperoni", Description = "Wonderful pizza for all family"},
                Size = _sizes[(int)eSize.Medium],
                Price = 8,
                Weight = 700
            },
            new PizzaSize
            {
                Id = 3,
                Pizza = new Pizza {Id = 1, Image = "", Name = "Pepperoni", Description = "Wonderful pizza for all family"},
                Size = _sizes[(int)eSize.Medium],
                Price = 12,
                Weight = 1100
            },
            new PizzaSize
            {
                Id = 4,
                Pizza = new Pizza {Id = 1, Image = "", Name = "Capricious", Description = "Popular Italian pizza"},
                Size = _sizes[(int)eSize.Small],
                Price = 6,
                Weight = 450
            }
        };

        public Task<List<PizzaSize>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PizzaSize> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
