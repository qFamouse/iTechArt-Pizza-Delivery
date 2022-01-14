using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Ingredient;

namespace iTechArtPizzaDelivery.Core.Mapping
{
    class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<IngredientInsertRequest, Ingredient>();
            CreateMap<IngredientUpdateRequest, Ingredient>();
        }
    }
}
