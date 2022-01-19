using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Views;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Shopping
{
    public interface IAnalyticalService
    {
        Task<BestPizzaSizeView> GetBestSellingPizzaByMonthAsync(int month);
        Task<List<User>> GetRegularCustomersAsync();
    }
}