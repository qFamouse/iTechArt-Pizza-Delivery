using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.User;

namespace iTechArtPizzaDelivery.Core.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationRequest, User>()
                // UserName is Email
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.Email));
        }
    }
}
