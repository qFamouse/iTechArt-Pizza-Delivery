﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Promocode;

namespace iTechArtPizzaDelivery.Core.Mapping
{
    class PromocodeProfile : Profile
    {
        public PromocodeProfile()
        {
            CreateMap<PromocodeInsertRequest, Promocode>();
            CreateMap<PromocodeUpdateRequest, Promocode>();
        }
    }
}
