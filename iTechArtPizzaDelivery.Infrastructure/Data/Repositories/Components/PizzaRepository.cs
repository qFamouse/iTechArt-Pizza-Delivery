using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Configurations;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Components
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        private readonly PaginationConfiguration _paginationConfiguration;

        public PizzaRepository(PizzaDeliveryContext context, IMapper mapper, IOptions<PaginationConfiguration> paginationConfiguration) : base(context, mapper)
        {
            _paginationConfiguration = paginationConfiguration.Value ??
                                       throw new NullReferenceException(nameof(paginationConfiguration));
        }

        public Task<List<Pizza>> GetAllByPageAsync(int pageNumber)
        {
            return DbContext.Pizzas.ToPageable(pageNumber, _paginationConfiguration.DefaultPageSize).ToListAsync();
        }
    }
}