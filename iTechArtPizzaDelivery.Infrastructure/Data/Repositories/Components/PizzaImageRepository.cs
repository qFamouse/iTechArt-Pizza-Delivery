using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Components
{
    public class PizzaImageRepository : BaseRepository<PizzaImage>, IPizzaImageRepository
    {
        public PizzaImageRepository(PizzaDeliveryContext context, IMapper mapper): base(context, mapper) { }
    }
}
