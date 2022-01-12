using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Pizza;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Profiles
{
    public class PizzaProfile : Profile
    {
        public PizzaProfile()
        {
            CreateMap<PizzaAddRequest, Pizza>();
        }
    }
}
