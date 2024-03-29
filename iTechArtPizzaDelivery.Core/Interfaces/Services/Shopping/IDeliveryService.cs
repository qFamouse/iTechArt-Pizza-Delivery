﻿using System.Collections.Generic;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Delivery;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IDeliveryService
    {
        Task<List<Delivery>> GetAllAsync();
        Task<Delivery> GetByIdAsync(int id);
        Task<Delivery> AddAsync(DeliveryInsertRequest request);
        Task DeleteByIdAsync(int id);
        Task<Delivery> UpdateByIdAsync(int id, DeliveryUpdateRequest request);
    }
}
