﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.PizzaSize;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Profiles
{
    public class PizzaSizeProfile : Profile
    {
        public PizzaSizeProfile()
        {
            CreateMap<PizzaSizeAddRequest, PizzaSize>();
        }
    }
}
