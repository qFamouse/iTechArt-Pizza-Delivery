using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Ingredient;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Components
{
    public interface IIngredientsService
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> GetByIdAsync(int id);
        Task<Ingredient> AddAsync(IngredientAddRequest request);
        Task DeleteByIdAsync(int id);
        Task<Ingredient> UpdateByIdAsync(int id, IngredientUpdateRequest request);
    }
}
