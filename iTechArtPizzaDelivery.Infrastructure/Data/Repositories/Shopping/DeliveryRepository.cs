using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Shopping
{
    public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        //public async Task<Delivery> AddAsync(DeliveryAddRequest request)
        //{
        //    var delivery = Mapper.Map<Delivery>(request);
        //    await DbContext.Deliveries.AddAsync(delivery);
        //    await DbContext.SaveChangesAsync();
        //    return delivery;
        //}

        //public async Task DeleteByIdAsync(int id)
        //{
        //    var delivery = await DbContext.Deliveries
        //        .SingleAsync(d => d.Id == id);
        //    DbContext.Deliveries.Remove(delivery);
        //    await DbContext.SaveChangesAsync();
        //}

        //public async Task<List<Delivery>> GetAllAsync()
        //{
        //    return await DbContext.Deliveries.ToListAsync();
        //}
    }
}
