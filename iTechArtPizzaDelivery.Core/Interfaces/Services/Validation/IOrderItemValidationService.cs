using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Validation
{
    public interface IOrderItemValidationService
    {
        Task OrderItemExistsAsync(int id);
    }
}
