﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.OrderItem;

namespace iTechArtPizzaDelivery.Core.Mapping
{
    class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItemUpdateRequest, OrderItem>();
            CreateMap<OrderItemUpdateRequest, OrderItem>();
        }
    }
}
