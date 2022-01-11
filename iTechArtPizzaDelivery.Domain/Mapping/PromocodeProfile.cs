using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.Promocode;

namespace iTechArtPizzaDelivery.Domain.Mapping
{
    class PromocodeProfile : Profile
    {
        public PromocodeProfile()
        {
            CreateMap<PromocodeAddRequest, Promocode>();
        }
    }
}
