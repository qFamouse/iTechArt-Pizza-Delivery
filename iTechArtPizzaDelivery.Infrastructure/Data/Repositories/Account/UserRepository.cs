using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Account
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }
    }
}
