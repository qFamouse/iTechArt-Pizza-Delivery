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
    public class PromocodeRepository : BaseRepository<Promocode>, IPromocodeRepository
    {
        public PromocodeRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<List<Promocode>> GetAllAsync()
        {
            return await DbContext.Promocodes.ToListAsync();
        }

        public async Task<Promocode> GetByCodeAsync(string code)
        {
            return await DbContext.Promocodes
                .SingleAsync(p => p.Code == code);
        }

        public async Task<Promocode> AddAsync(Promocode promocode)
        {
            await DbContext.Promocodes.AddAsync(promocode);
            await DbContext.SaveChangesAsync();
            return promocode;
        }
    }
}
