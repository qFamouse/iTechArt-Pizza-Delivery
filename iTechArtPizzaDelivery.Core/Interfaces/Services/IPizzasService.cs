using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Pizza;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IPizzasService
    {
        Task<List<Pizza>> GetAllAsync();
        Task<Pizza> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<Pizza> AddAsync(PizzaAddRequest request);
    }
}
