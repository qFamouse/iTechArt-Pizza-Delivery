using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Promocode;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IPromocodeService
    {
        Task<List<Promocode>> GetAllAsync();
        Task<Promocode> AddAsync(PromocodeAddRequest request);
    }
}
