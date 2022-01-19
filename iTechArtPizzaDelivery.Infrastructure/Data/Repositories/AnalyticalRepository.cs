using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Views;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories
{
    public class AnalyticalRepository : IAnalyticalRepository
    {
        private readonly PizzaDeliveryContext _pizzaDeliveryContext;

        public AnalyticalRepository(PizzaDeliveryContext pizzaDeliveryContext)
        {
            _pizzaDeliveryContext =
                pizzaDeliveryContext ?? throw new ArgumentNullException(nameof(pizzaDeliveryContext));
        }

        public async Task<BestPizzaSizeView> GetBestSellingPizzaByMonth(int month)
        {
            BestPizzaSizeView pizzaSizeView = null;

            var queryString = string.Format(
                $@"SELECT TOP(1) oi.PizzaSizeId, COUNT(*) AS NumberOfOrders 
                  FROM OrderItems oi 
                  INNER JOIN Orders o ON oi.OrderId = o.id
                  WHERE (MONTH(o.CreateAt) = {month}) AND (o.Status > 1) 
                  GROUP BY oi.PizzaSizeId 
                  ORDER BY NumberOfOrders DESC");

            var dbConnection = _pizzaDeliveryContext.Database.GetDbConnection();
            await using (var command = dbConnection.CreateCommand())
            {
                await dbConnection.OpenAsync();

                command.CommandText = queryString;
                await using var dbDataReader = await command.ExecuteReaderAsync(
                    CommandBehavior.CloseConnection | CommandBehavior.SingleRow); // TODO: Close connection?

                if (await dbDataReader.ReadAsync())
                {
                    pizzaSizeView = new BestPizzaSizeView()
                    {
                        PizzaSize = new PizzaSize() { Id = Convert.ToInt32(dbDataReader["PizzaSizeId"]) },
                        NumberOfOrders = Convert.ToInt32(dbDataReader["NumberOfOrders"]),
                        PerMonth = month
                    };
                }
                //await dbConnection.CloseAsync();
            }

            return pizzaSizeView;
        }
    }
}
