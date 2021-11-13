﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Requests;
using iTechArtPizzaDelivery.Domain.Requests.PizzaSize;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PizzaSizeEFRepository : BaseEFRepository, IPizzasSizesRepository
    {
        private IMapper _mapper;
        public PizzaSizeEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        public async Task<List<PizzaSize>> GetAllAsync()
        {
            return await _dbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .ToListAsync();
        }

        public async Task<PizzaSize> GetByIdAsync(int id)
        {
            return await _dbContext.PizzasSizes
                .Include(p => p.Pizza)
                .Include(s => s.Size)
                .FirstOrDefaultAsync(ps => ps.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var pizza = await _dbContext.PizzasSizes.FirstOrDefaultAsync(ps => ps.Id == id);
            _dbContext.PizzasSizes.Remove(pizza);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PizzaSize> AddAsync(PizzaSizeAddRequest psAddRequest)
        {
            // Mapping
            var pizzaSize = _mapper.Map<PizzaSize>(psAddRequest);
            pizzaSize.Pizza = await _dbContext.Pizzas.SingleAsync(p => p.Id == psAddRequest.PizzaId);
            pizzaSize.Size = await _dbContext.Sizes.SingleAsync(s => s.Id == psAddRequest.SizeId);
            // Adding
            await _dbContext.PizzasSizes.AddAsync(pizzaSize);
            await _dbContext.SaveChangesAsync();
            return pizzaSize;
        }
    }
}
