using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Mapping
{
    public class PizzaIngredientProfile : Profile
    {
        public PizzaIngredientProfile()
        {
            CreateMap<PizzaIngredient, PizzaIngredientView>();

            CreateMap<PizzaIngredient, PizzaIngredientDetailView>();
        }
    }
}
