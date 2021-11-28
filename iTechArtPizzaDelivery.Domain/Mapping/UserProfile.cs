using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.User;

namespace iTechArtPizzaDelivery.Domain.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationRequest, User>()
                // UserName is Email
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.Email))
                // Email is Null
                .ForMember(dest => dest.Email, opt => opt.Ignore());
        }
    }
}
