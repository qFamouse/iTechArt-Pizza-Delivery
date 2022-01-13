using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Shopping
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<OrderItem> Add(OrderItem orderItem)
        {
            await DbContext.OrderItems.AddAsync(orderItem);
            await DbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task DeleteById(int id)
        {
            DbContext.Remove(await DbContext.OrderItems.
                SingleAsync(oi => oi.Id == id));
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<OrderItem>> GetAllByOrderIdAsync(int id)
        {
            return await DbContext.OrderItems
                .Include(oi => oi.PizzaSize)
                .ThenInclude(ps => ps.Pizza)
                .Include(oi => oi.PizzaSize)
                .ThenInclude(ps => ps.Size)
                .Include(oi => oi.PizzaSize)
                .ThenInclude(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .Where(oi => oi.Order.Id == id)
                .ToListAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await DbContext.OrderItems
                .Include(oi => oi.PizzaSize)
                .ThenInclude(ps => ps.PizzaIngredients)
                .ThenInclude(pi => pi.Ingredient)
                .SingleAsync(oi => oi.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
