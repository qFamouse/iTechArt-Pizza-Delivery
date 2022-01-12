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
    public class DeliveryEFRepository : BaseEFRepository, IDeliveryRepository
    {
        public DeliveryEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Delivery> AddAsync(DeliveryAddRequest request)
        {
            var delivery = _mapper.Map<Delivery>(request);
            await _dbContext.Deliveries.AddAsync(delivery);
            await _dbContext.SaveChangesAsync();
            return delivery;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var delivery = await _dbContext.Deliveries
                .SingleAsync(d => d.Id == id);
            _dbContext.Deliveries.Remove(delivery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Delivery>> GetAllAsync()
        {
            return await _dbContext.Deliveries.ToListAsync();
        }
    }
}
