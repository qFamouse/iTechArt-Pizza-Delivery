using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Delivery;

namespace iTechArtPizzaDelivery.Core.Mapping
{
    class DeliveryProfile : Profile
    {
        public DeliveryProfile()
        {
            CreateMap<DeliveryAddRequest, Delivery>();
            CreateMap<DeliveryUpdateRequest, Delivery>();
        }
    }
}
