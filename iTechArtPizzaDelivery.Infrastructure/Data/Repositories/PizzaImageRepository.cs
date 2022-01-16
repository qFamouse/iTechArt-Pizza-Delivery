using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories
{
    public class PizzaImageRepository : BaseRepository<PizzaImage>, IPizzaImageRepository
    {
        public PizzaImageRepository(PizzaDeliveryContext context, IMapper mapper): base(context, mapper) { }
    }
}
