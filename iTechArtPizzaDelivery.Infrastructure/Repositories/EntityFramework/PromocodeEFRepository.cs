using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
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
    }
}
