using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Mapping
{
    public class PizzaSizeProfile : Profile
    {
        public PizzaSizeProfile()
        {
            CreateMap<PizzaSize, PizzaSizeDetailView>();
            CreateMap<PizzaSize, PizzaSizeView>();
        }
    }
}
