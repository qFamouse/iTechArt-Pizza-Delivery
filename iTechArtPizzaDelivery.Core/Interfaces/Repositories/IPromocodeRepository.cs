﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IPromocodeRepository : IBaseRepository<Promocode>
    {
        Task<Promocode> GetByCodeAsync(string code);
        Task<bool> IsExistingCode(string code);
    }
}
