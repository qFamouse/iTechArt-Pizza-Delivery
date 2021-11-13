using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Profiles
{
    public class PizzaIngredientProfile : Profile
    {
        public PizzaIngredientProfile()
        {
            CreateMap<PizzaIngredient, PizzaIngredientView>();
        }
    }
}
