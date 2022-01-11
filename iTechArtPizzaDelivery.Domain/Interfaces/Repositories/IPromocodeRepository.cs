using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Repositories
{
    public interface IPromocodeRepository
    {
        Task<List<Promocode>> GetAllAsync();
        Task<Promocode> GetByCodeAsync(string code);
        Task<Promocode> AddAsync(Promocode promocode);

    }
}
