using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDetailView>();

            CreateMap<Order, OrderView>();
        }
    }
}
