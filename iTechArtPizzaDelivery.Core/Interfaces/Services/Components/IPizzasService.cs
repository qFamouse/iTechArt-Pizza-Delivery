﻿using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Pizza;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Components
{
    public interface IPizzasService
    {
        Task<List<Pizza>> GetAllAsync();
        Task<Pizza> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task<Pizza> AddAsync(PizzaAddRequest request);
        Task<Pizza> UpdateByIdAsync(int id, PizzaUpdateRequest request);
    }
}
