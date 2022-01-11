using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Pizza;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IPizzasService
    {
        Task<List<Pizza>> GetAllAsync();
        Task<Pizza> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<Pizza> AddAsync(PizzaAddRequest request);
    }
}
