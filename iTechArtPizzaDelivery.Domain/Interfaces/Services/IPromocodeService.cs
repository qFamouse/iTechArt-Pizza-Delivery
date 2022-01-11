using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Promocode;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface IPromocodeService
    {
        Task<List<Promocode>> GetAllAsync();
        Task<Promocode> AddAsync(PromocodeAddRequest request);
    }
}
