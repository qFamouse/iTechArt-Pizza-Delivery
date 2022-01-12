using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.Delivery;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Delivery> AddAsync(DeliveryAddRequest request)
        {
            var delivery = Mapper.Map<Delivery>(request);
            await DbContext.Deliveries.AddAsync(delivery);
            await DbContext.SaveChangesAsync();
            return delivery;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var delivery = await DbContext.Deliveries
                .SingleAsync(d => d.Id == id);
            DbContext.Deliveries.Remove(delivery);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<Delivery>> GetAllAsync()
        {
            return await DbContext.Deliveries.ToListAsync();
        }
    }
}
