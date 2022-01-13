using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Shopping
{
    public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

    }
}
