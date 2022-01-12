using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<List<User>> GetAllAsync()
        {
            return await DbContext.Users
                .Include(o => o.Orders)
                .ToListAsync();
        }
    }
}
