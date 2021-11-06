using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Interfaces.Services
{
    interface ISizesService
    {
        public Task<List<Size>> GetAllAsync();
        public Task<Size> GetByIdAsync(int id);
        public Task<Size> AddAsync(Size size);
    }
}
