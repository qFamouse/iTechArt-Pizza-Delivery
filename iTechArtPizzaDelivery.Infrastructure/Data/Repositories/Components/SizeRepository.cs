using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.Size;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Components
{
    public class SizeRepository : BaseRepository<Size>, ISizeRepository
    {
        public SizeRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

    }
}
