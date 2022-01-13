using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.Pizza;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Components
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }
    }
}