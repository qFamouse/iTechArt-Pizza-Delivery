﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Ingredient;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IIngredientRepository
    {
        #region Getters

        public Task<List<Ingredient>> GetAllAsync();
        public Task<Ingredient> GetByIdAsync(int id);

        #endregion

        public Task<Ingredient> AddAsync(IngredientAddRequest iAddRequest);
    }
}
