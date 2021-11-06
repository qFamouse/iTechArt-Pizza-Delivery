using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IIngredientsService
    {
        public Task<List<Ingredient>> GetAllAsync();
        public Task<Ingredient> GetByIdAsync(int id);
        public Task<Ingredient> AddAsync(Ingredient pizza);
    }
}
