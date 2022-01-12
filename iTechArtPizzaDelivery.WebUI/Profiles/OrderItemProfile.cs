using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDetailView>();

            CreateMap<OrderItem, OrderItemView>();
        }
    }
}
