using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Ingredient;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IIngredientsService
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> GetByIdAsync(int id);
        Task<Ingredient> AddAsync(IngredientAddRequest request);
    }
}
