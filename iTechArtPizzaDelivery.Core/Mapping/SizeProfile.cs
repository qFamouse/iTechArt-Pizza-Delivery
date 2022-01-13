using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Size;

namespace iTechArtPizzaDelivery.Core.Mapping
{
    class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<SizeAddRequest, Size>();
        }
    }
}
