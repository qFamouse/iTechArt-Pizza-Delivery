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
    }
}
