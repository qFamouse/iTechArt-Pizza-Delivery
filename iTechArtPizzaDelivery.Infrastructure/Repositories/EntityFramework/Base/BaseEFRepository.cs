using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base
{
    public class BaseEFRepository
    {
        private protected readonly PizzaDeliveryContext _dbContext;

        public BaseEFRepository(PizzaDeliveryContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context), "DB Context is null");
        }
    }
}
