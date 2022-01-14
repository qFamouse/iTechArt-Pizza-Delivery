using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Validation
{
    public interface ISizesValidationService
    {
        Task SizeExistsAsync(int id);
    }
}
