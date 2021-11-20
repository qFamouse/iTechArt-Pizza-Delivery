using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Profiles
{
    public class PizzaIngredientProfile : Profile
    {
        public PizzaIngredientProfile()
        {
            CreateMap<PizzaIngredientBindRequest, PizzaIngredient>();
        }
    }
}
