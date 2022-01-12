using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PromocodeEFRepository : BaseEFRepository, IPromocodeRepository
    {
        public PromocodeEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<List<Promocode>> GetAllAsync()
        {
            return await _dbContext.Promocodes.ToListAsync();
        }

        public async Task<Promocode> GetByCodeAsync(string code)
        {
            return await _dbContext.Promocodes
                .SingleAsync(p => p.Code == code);
        }

        public async Task<Promocode> AddAsync(Promocode promocode)
        {
            await _dbContext.Promocodes.AddAsync(promocode);
            await _dbContext.SaveChangesAsync();
            return promocode;
        }
    }
}
