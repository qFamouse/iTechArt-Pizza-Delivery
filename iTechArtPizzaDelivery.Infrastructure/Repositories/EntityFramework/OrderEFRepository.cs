using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Requests.Order;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class OrderEFRepository : BaseEFRepository, IOrderRepository
    {
        public OrderEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) {}

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders
                .Include(o => o.Promocode)
                .ToListAsync();
        }

        public async Task AddPromocode(OrderAddPromocodeRequest oAddPromocodeRequest)
        {
            var promocode = await _dbContext.Promocodes
                .SingleAsync(p => p.Code == oAddPromocodeRequest.Code);
            var order = await _dbContext.Orders
                .SingleAsync(o => o.Id == oAddPromocodeRequest.Id);

            if (order.Promocode is not null)
            {
                throw new ArgumentException("The order already has an active promo code", nameof(order.Promocode));
            }

            switch ((MeasureType)promocode.Measure)
            {
                case MeasureType.Percent:
                    order.Price *= promocode.Discount;
                    break;
                case MeasureType.Money:
                    order.Price -= promocode.Discount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(promocode.Measure), "Invalid measure value");
            }

            order.Promocode = promocode;
            await _dbContext.SaveChangesAsync();
        }
    }
}
