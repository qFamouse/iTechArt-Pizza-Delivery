using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Ingredient;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IIngredientsService
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> GetByIdAsync(int id);
        Task<Ingredient> AddAsync(IngredientAddRequest request);
    }
}
