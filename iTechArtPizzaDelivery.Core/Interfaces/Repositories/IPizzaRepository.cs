using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Pizza;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IPizzaRepository : IBaseRepository<Pizza>
    {
        Task<List<Pizza>> GetAllByPageAsync(int pageNumber);
    }
}