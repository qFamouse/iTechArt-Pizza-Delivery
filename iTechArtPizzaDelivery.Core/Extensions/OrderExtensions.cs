using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Extensions
{
    public static class OrderExtensions
    {
        public static void Recalculate(this Order order)
        {
            // Initial Data //
            Promocode promocode = order.Promocode;
            double price = 0;

            // Add Item Prices //
            foreach (var orderItem in order.OrderItems)
            {
                price += orderItem.Price;
            }

            // If Promocode is exists, then include discount //
            if (promocode is not null)
            {
                switch ((MeasureType)promocode.Measure)
                {
                    case MeasureType.Percent:
                        price *= order.Promocode.Discount / 100;
                        break;
                    case MeasureType.Money:
                        price -= order.Promocode.Discount;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(order.Promocode.Measure), "Invalid measure value");
                }
            }

            // If Price is Negative Value, then it free //
            if (price < 0) { price = 0; }

            // Save price //
            order.Price = price;
        }
    }
}
