using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.WebUI.Views;

namespace iTechArtPizzaDelivery.WebUI.Mapping
{
    public class PizzaSizesProfile : Profile
    {
        public PizzaSizesProfile()
        {
            CreateMap<PizzaSize, PizzaSizesView>();
        }
    }
}
