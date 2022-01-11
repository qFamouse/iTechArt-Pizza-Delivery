using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;

namespace iTechArtPizzaDelivery.Domain.Extensions
{
    public static class OrderItemExtensions
    {
        public static void Recalculate(this OrderItem orderItem)
        {
            double weight = orderItem.PizzaSize.Weight;
            double price = orderItem.PizzaSize.Price * orderItem.Quantity;

            foreach (var pizzaIngredient in orderItem.PizzaSize.PizzaIngredients)
            {
                weight += pizzaIngredient.Weight;
                price += pizzaIngredient.Ingredient.Price;
            }

            orderItem.Weight = weight;
            orderItem.Price = price;
        }
    }
}
