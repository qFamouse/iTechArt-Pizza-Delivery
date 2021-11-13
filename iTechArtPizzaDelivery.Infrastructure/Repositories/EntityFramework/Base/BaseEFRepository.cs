using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base
{
    public class BaseEFRepository
    {
        private protected readonly PizzaDeliveryContext _dbContext;
        private protected readonly IMapper _mapper;

        public BaseEFRepository(PizzaDeliveryContext context, IMapper mapper)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context), "DB Context is null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }
    }
}
