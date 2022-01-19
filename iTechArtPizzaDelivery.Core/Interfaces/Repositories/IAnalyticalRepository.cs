using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Views;

namespace iTechArtPizzaDelivery.Core.Interfaces.Repositories
{
    public interface IAnalyticalRepository
    {
        Task<BestPizzaSizeView> GetBestSellingPizzaByMonth(int month);
    }
}
