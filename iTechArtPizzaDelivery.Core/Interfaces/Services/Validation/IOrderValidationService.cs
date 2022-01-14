using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Validation
{
    public interface IOrderValidationService
    {
        void OrderReadyToDelivery(Order order);
        void OrderInProgress(Order order);
    }
}
