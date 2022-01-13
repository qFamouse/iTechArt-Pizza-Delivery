using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.PizzaIngredient;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Construction
{
    public class PizzaIngredientRepository : BaseRepository<PizzaIngredient>, IPizzaIngredientRepository
    {
        public PizzaIngredientRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }
    }
}
